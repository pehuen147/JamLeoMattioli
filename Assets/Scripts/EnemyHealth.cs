using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    float health = 0;

    const string playerBulletTag = "PlayerBullet";

    EnemyAI enemyAI;
    EnemyData data;

    private void OnEnable()
    {
        health = data.maxHealth;
    }

    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        data = enemyAI.GetData();
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
            Death();
    }

    public override void Death()
    {
        this.gameObject.SetActive(false);
    }
}
