using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    float health = 0;

    const string playerBulletTag = "PlayerBullet";

    EnemyAI enemyAI;
    EnemyData data;
    AudioSource aSource;

    private void OnEnable()
    {
        health = data.maxHealth;
    }

    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        data = enemyAI.GetData();
        aSource = GetComponent<AudioSource>();
    }

    public override void TakeDamage(float damage, int bulletColorIndex)
    {
        if (bulletColorIndex == enemyAI.GetCurrentColor())
            health -= damage;
        else
            SoundManager.SharedInstance.PlayReflectShot();

        if (health <= 0)
            Death();
    }

    public override void Death()
    {

        SoundManager sManager = SoundManager.SharedInstance;

        sManager.PlayOneShotPlayer(sManager.enemyDeathSFX);

        this.gameObject.SetActive(false);
    }
}
