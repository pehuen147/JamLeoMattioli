using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    Animator animator;
    PlayerMovement movement;
    GunController gunController;
    ChangeColor colorChanger;
    PlayerData data;

    const string reloadCommand = "Reload";
    const string shotCommand = "Shot";
    const string isMovingCommand = "IsMoving";

    public float cooldownToFire = 1;
    private float cooldownTimer;
    bool lastIsMoving = false;

    [SerializeField] GameObject spawnBulletPoint;
    [SerializeField] GameObject gun;

    Transform mainCameraTransform;
    private void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<PlayerMovement>();
        colorChanger = gun.GetComponent<ChangeColor>();

        data = movement.GetData();

        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (cooldownTimer >= 0)
            cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0)
            cooldownTimer = 0;

        if (Input.GetButtonDown("Fire1") && cooldownTimer == 0)
        {
            cooldownTimer = cooldownToFire;
            GunShot();
        }
        
        else if (Input.GetButtonDown("Fire2"))
           Reload();

        if (lastIsMoving != movement.IsMoving())
            animator.SetBool(isMovingCommand, movement.IsMoving());

        lastIsMoving = movement.IsMoving();
    }

    private void GunShot()
    {
        animator.SetTrigger(shotCommand);

        GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
        bullet.transform.position = spawnBulletPoint.transform.position;
        bullet.transform.rotation = mainCameraTransform.rotation;

        bullet.tag = GameManager.playerTag;

        Renderer bulletRenderer = bullet.GetComponent<Renderer>();

        int currentColor = colorChanger.GetCurrentColor();

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        bulletScript.SetBulletColor(currentColor);
        bulletScript.SetDamage(data.damage);
    }

    private void Reload()
    {
        animator.SetTrigger(reloadCommand);
    }
}
