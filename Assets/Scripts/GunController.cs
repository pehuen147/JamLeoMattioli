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
    AudioSource audioSource;

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
        audioSource = GetComponentInParent<AudioSource>();
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
        // Shot sound
        SoundManager soundManager = SoundManager.SharedInstance;
        soundManager.PlayOneShot(soundManager.playerShotSFX, audioSource);

        // Animation
        animator.SetTrigger(shotCommand);

        // Projectile
        GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
        bullet.transform.position = spawnBulletPoint.transform.position;
        bullet.transform.rotation = mainCameraTransform.rotation;

        bullet.tag = GameManager.playerTag;
        bullet.layer = LayerMask.NameToLayer(GameManager.enemyTag);

        // Projectile color
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
