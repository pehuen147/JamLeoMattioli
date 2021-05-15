using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] Transform bulletSpawn;

    EnemyAI enemyAI;
    EnemyData enemyData;

    float shotCooldown;
    float shotTimer;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();

        enemyData = enemyAI.GetData();
        shotCooldown = enemyData.shotCooldown;
    }

    private void Update()
    {
        shotTimer -= Time.deltaTime;

        if (shotTimer <= 0)
        {
            Shoot();
            shotTimer = shotCooldown;
        }
    }

    private void Shoot()
    {

        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();

        bullet.tag = GameManager.enemyTag;

        bullet.transform.position = bulletSpawn.position;

        bullet.transform.LookAt(PlayerSingleton.Instance.transform);
    }
}
