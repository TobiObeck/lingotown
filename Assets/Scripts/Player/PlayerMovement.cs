using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    public float gravity = -9.81f;
    public Vector3 velocity;
    public float jumpHeight = 3f;


    public Transform groundCheckNode;
    public float groundDistance = 0.4f; // basically the radius of the sphere
    public LayerMask groundMask;

    private bool isGrounded;


    void Update()
    {
        this.isGrounded = Physics.CheckSphere(
            groundCheckNode.position, groundDistance, groundMask);

        if(this.isGrounded && this.velocity.y < 0){
            this.velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
        this.controller.Move(Time.deltaTime * speed * moveDirection);

        if(Input.GetButtonDown("Jump") && this.isGrounded){
            this.velocity.y = Mathf.Sqrt(this.jumpHeight * (-2f) * gravity);
        }

        this.velocity.y += gravity * Time.deltaTime;
        this.controller.Move(this.velocity * Time.deltaTime);
    }
}
