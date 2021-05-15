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

<<<<<<< HEAD
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] GameObject SpawnBulletPoint;
=======
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject spawnBulletPoint;
    [SerializeField] GameObject gun;

>>>>>>> 4ce0e47cfc2235c9c618f76a8c12901e2b045129
    private void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<PlayerMovement>();
        colorChanger = gun.GetComponent<ChangeColor>();
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

        GameObject bullet = Instantiate(bulletPrefab, spawnBulletPoint.transform.position, Camera.main.transform.rotation);

        Renderer bulletRenderer = bullet.GetComponent<Renderer>();

        bulletRenderer.material.SetColor("_Color", colorChanger.GetCurrentColor());
    }

    private void Reload()
    {
        animator.SetTrigger(reloadCommand);
    }
}
