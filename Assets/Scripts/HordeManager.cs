using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeManager : MonoBehaviour
{
    [SerializeField] Transform[] spawners;
    [SerializeField] int initialSpawnedEnemies = 3;
    [SerializeField] float waitTimeToSpawn = .5f;

    int hordeCounter = 1;


    IEnumerator spawnCoroutine;

    private void Update()
    {
        bool hordeDead = EnemyPool.SharedInstance.CheckHorde();

        if (hordeDead)
        {
            SpawnHorde();
            hordeCounter++;
        }
    }

    void SpawnHorde()
    {
        int amountToSpawn = hordeCounter * initialSpawnedEnemies;
        spawnCoroutine = WaitToSpawn(waitTimeToSpawn, amountToSpawn);

        StartCoroutine(spawnCoroutine);
    }

    IEnumerator WaitToSpawn(float waitTime, int amount)
    {
        while (amount > 0)
        {
            amount--;

            Spawn();

            yield return new WaitForSeconds(waitTime);

        }
    }

    void Spawn()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            GameObject enemy = EnemyPool.SharedInstance.GetPooledObject();
            enemy.transform.position = spawners[i].position;
        }
    }
}
