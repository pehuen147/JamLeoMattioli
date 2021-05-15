using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    Animator animator;
    PlayerMovement movement;
    GunController gunController;
    ChangeColor colorChanger;

    const string reloadCommand = "Reload";
    const string shotCommand = "Shot";
    const string isMovingCommand = "IsMoving";

    bool lastIsMoving = false;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject spawnBulletPoint;
    [SerializeField] GameObject gun;

    Transform mainCameraTransform;
    private void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<PlayerMovement>();
        colorChanger = gun.GetComponent<ChangeColor>();

        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            GunShot();
        else if (Input.GetButtonDown(reloadCommand))
            Reload();


        if (lastIsMoving != movement.IsMoving())
            animator.SetBool(isMovingCommand, movement.IsMoving());


        lastIsMoving = movement.IsMoving();
    }

    private void GunShot()
    {
        animator.SetTrigger(shotCommand);

        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        bullet.transform.position = spawnBulletPoint.transform.position;
        bullet.transform.rotation = mainCameraTransform.rotation;

        Renderer bulletRenderer = bullet.GetComponent<Renderer>();

        bulletRenderer.material.SetColor("_Color", colorChanger.GetCurrentColor());
    }

    private void Reload()
    {
        animator.SetTrigger(reloadCommand);
    }
}