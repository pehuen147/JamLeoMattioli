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
    }

    private void Reload()
    {
        animator.SetTrigger(reloadCommand);
    }
}
