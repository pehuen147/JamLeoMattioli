using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTime;

    private float spawnTimer = 0;

    private void Update()
    {
        if (spawnTimer <= 0)
        {
            spawnTimer = spawnTime;
            Spawn();
        }

        spawnTimer -= Time.deltaTime;
    }

    public void Spawn()
    {
        GameObject enemy = EnemyPool.SharedInstance.GetPooledObject();

        enemy.transform.position = transform.position;
        enemy.transform.rotation = Quaternion.identity;
    }
}
