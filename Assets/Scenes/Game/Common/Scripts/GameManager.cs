using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ObjectPooler objectPooler;
    private float maxSpawnInterval = 4;
    private float spawnInterval = 0;
    
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void Update()
    {
        spawnInterval += Time.deltaTime;
        if (spawnInterval > maxSpawnInterval)
        {
            Spawn();
            spawnInterval = 0;
        }
    }

    private void Spawn()
    {
        Vector3 position = new Vector3(Random.Range(0, 2), Random.Range(-90f, 90f), 0);
        if (position.x == 0)
        {
            position.x = -180f;
        } 
        else
        {
            position.x = 180f;
        }
        objectPooler.SpawnFromPool("Asteroid", position, Quaternion.identity);
    }
}
