using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private ObjectPooler objectPooler;
    
    public float maxFireCooldown;
    private float fireCooldown;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void Update()
    {
        fireCooldown += Time.deltaTime;
        if (fireCooldown > maxFireCooldown)
        {
            Fire();
            fireCooldown = 0;
        }
    }

    void Fire()
    {
        objectPooler.SpawnFromPool("Player Bullet", transform.position, transform.rotation);
    }
}
