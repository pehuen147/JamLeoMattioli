using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
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
        Instantiate<GameObject>(enemy, transform.position, Quaternion.identity);
    }
}
