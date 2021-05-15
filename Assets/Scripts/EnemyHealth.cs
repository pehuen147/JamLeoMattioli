using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
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

    public override void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
            Death();
    }

    public override void Death()
    {
        Destroy(this.gameObject);
    }
}
