using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterBehaviour : MonoBehaviour
{

    private ObjectPooler objectPooler;

    public float huntingSpeed;
    public float lookingSpeed;
    public float huntingTurnSpeed;
    public float lookingTurnSpeed;
    public float maxFireCooldown;

    public GameObject bullet;

    private bool hunting = false;   
    private float fireCooldown;
    private RaycastHit2D hit;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        GetComponent<MoveForward>().speed = lookingSpeed;
    }

    // Update is called once per frame
    void Update()
    {   
        int layerMask = 1 << 3;

        hit = Physics2D.Raycast(transform.position, transform.up, Mathf.Infinity, layerMask);
        if (hit.collider != null && hunting == false)
        {
            StartCoroutine(Hunt());
        }
    }

    IEnumerator Hunt()
    {
        StartCoroutine(Burst());
        hunting = true;
        GetComponent<MoveForward>().speed = huntingSpeed;
        GetComponent<RotateTowardsPlayer>().rotationSpeed = huntingTurnSpeed;
        yield return new WaitForSeconds(1);
        hunting = false;
        GetComponent<MoveForward>().speed = lookingSpeed;
        GetComponent<RotateTowardsPlayer>().rotationSpeed = lookingTurnSpeed;
    }

    IEnumerator Burst()
    {
        objectPooler.SpawnFromPool("Enemy Bullet", transform.position, transform.rotation);
        yield return new WaitForSeconds(0.1f);
        objectPooler.SpawnFromPool("Enemy Bullet", transform.position, transform.rotation);
        yield return new WaitForSeconds(0.1f);
        objectPooler.SpawnFromPool("Enemy Bullet", transform.position, transform.rotation);
        yield return new WaitForSeconds(0.1f);
    }
}
