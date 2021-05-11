using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float gravity = -9.81f;
    private CharacterController controller;
    private Vector3 velocity;

    private float mouseX;
    private float mouseY;

    [SerializeField] PlayerData m_PlayerData;
    [SerializeField] GameObject m_Camera;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Gravity

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Jump
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {

            velocity.y = m_PlayerData.jumpHeight;
        }

        controller.Move(velocity * Time.deltaTime);

        // Movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        move = (transform.forward * Input.GetAxis("Vertical") 
              + transform.right * Input.GetAxis("Horizontal")) ;

        controller.Move(move * Time.deltaTime * m_PlayerData.speed);


       

        // Camera rotation
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, -90, 90);

        Vector2 mouseRotation = new Vector2(Input.GetAxis("Mouse X"), mouseY);
        transform.Rotate(0, mouseRotation.x, 0);
        m_Camera.transform.rotation = Quaternion.Euler(mouseY, 0, 0);
    }
}
