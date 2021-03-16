using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDirection : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        float angle = Mathf.Atan2(Random.Range(-90f, 90f) - transform.position.y,
                Random.Range(-160f, 160f) - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);       
    }
}
