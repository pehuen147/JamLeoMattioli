using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    Animator animator;

    PlayerMovement movement;

    const string reloadCommand = "Reload";
    const string shotCommand = "Shot";
    const string isMovingCommand = "IsMoving";

    bool lastIsMoving = false;

    [SerializeField] GameObject BulletPrefab;
    [SerializeField] GameObject SpawnBulletPoint;

    private void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<PlayerMovement>();
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

        Instantiate(BulletPrefab, SpawnBulletPoint.transform.position, Camera.main.transform.rotation);
    }

    private void Reload()
    {
        animator.SetTrigger(reloadCommand);
    }
}
