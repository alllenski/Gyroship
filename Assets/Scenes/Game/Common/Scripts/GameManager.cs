using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ObjectPooler objectPooler;

    private string[] enemyPools = {"Asteroid", "Missile", "Hunter"};
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
            int spawnAmount = Random.Range(1, 4);
            for (int i = 0; i < spawnAmount; i++)
            {
                Spawn();
            }
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
        objectPooler.SpawnFromPool(enemyPools[Random.Range(0, enemyPools.Length)], position, Quaternion.identity);
    }
}
