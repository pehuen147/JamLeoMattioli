using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float health = 0;

    const string playerBulletTag = "PlayerBullet";

    EnemyAI enemyAI;
    EnemyData data;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        data = enemyAI.GetData();

        health = data.maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerBulletTag))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
