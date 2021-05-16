using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] float dissintegrateSpeed;

    float health = 0;

    const string playerBulletTag = "PlayerBullet";

    EnemyAI enemyAI;
    EnemyData data;
    AudioSource aSource;
    Renderer rend;

    bool disintegrate;
    float disintegration = 0;

    IEnumerator waitToDestroyCoroutine;

    private void OnEnable()
    {
        health = data.maxHealth;
        disintegrate = false;
        disintegration = 0;

        enemyAI.enabled = true;
    }

    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        data = enemyAI.GetData();
        aSource = GetComponent<AudioSource>();
        rend = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        if (disintegrate)
        {
            if (disintegration < 1)
                disintegration += Time.deltaTime * dissintegrateSpeed;

            rend.material.SetFloat("_Weight", disintegration);
        }
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

        disintegrate = true;

        enemyAI.enabled = false;

        waitToDestroyCoroutine = waitToDestroy(dissintegrateSpeed);
        StartCoroutine(waitToDestroyCoroutine);
    }

    IEnumerator waitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        this.gameObject.SetActive(false);
    }
}
