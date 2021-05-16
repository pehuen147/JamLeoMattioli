using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnL;
    [SerializeField] Transform bulletSpawnR;
    [SerializeField] float shotWaitAnimationTime;

    GameObject player;
    EnemyAI enemyAI;
    EnemyData enemyData;
    Animator animator;

    float shotCooldown;
    float shotTimer;

    IEnumerator coroutine;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        animator = GetComponent<Animator>();

        player = PlayerSingleton.Instance.gameObject;

        enemyData = enemyAI.GetData();
        shotCooldown = enemyData.shotCooldown;
    }

    private void Update()
    {
        Vector3 diff = transform.position - player.transform.position;

        if (diff.magnitude < enemyData.minimumShootingDistance)
        {
            shotTimer -= Time.deltaTime;

            if (shotTimer <= 0)
            {
                Shoot();
                shotTimer = shotCooldown;
            }
        }
    }

    private void Shoot()
    {
        // Shooting with left and right arm randomly
        int leftRightShot = Random.Range(0, 2);

        switch (leftRightShot)
        {
            case (int)ShootingArm.left:
                animator.SetTrigger("ShootL");
                coroutine = WaitAndShoot(shotWaitAnimationTime, bulletSpawnL);
                break;

            case (int)ShootingArm.right:
                animator.SetTrigger("ShootR");
                coroutine = WaitAndShoot(shotWaitAnimationTime, bulletSpawnR);
                break;
        }


        StartCoroutine(coroutine);

        enemyAI.StopWhileShooting();
    }

    IEnumerator WaitAndShoot(float waitTime, Transform spawn)
    {
        yield return new WaitForSeconds(waitTime);

        GameObject bullet = BulletPool.SharedInstance.GetPooledObject();

        bullet.tag = GameManager.enemyTag;
        bullet.layer = LayerMask.NameToLayer(GameManager.playerTag);

        bullet.transform.position = spawn.position;

        bullet.transform.LookAt(player.transform);

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        bulletScript.SetBulletColor(enemyAI.GetCurrentColor());
        bulletScript.SetDamage(enemyAI.GetData().damage);
    }

    public enum ShootingArm { left , right };  
}
