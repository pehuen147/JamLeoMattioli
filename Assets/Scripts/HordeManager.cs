using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeManager : MonoBehaviour
{
    [SerializeField] Transform[] spawners;

    int hordeCounter = 0;

    [SerializeField] int initialSpawnedEnemies = 3;

    private void Update()
    {
        bool hordeDead = EnemyPool.SharedInstance.CheckHorde();

        if (hordeDead)
        {
            SpawnHorde();
        }
    }

    void SpawnHorde()
    {
        hordeCounter++;

        for (int i = 0; i < spawners.Length; i++)
        {
            for (int j = 0; j < hordeCounter; j++)
            {
                for (int k = 0; k < initialSpawnedEnemies; k++)
                {
                    GameObject enemy = EnemyPool.SharedInstance.GetPooledObject();
                    enemy.transform.position = spawners[i].position;
                }
            }
        }
    }
}
