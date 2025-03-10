﻿using UnityEngine;
using UnityEngine.InputSystem;

public class Controller1 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 10f;
    public int availableJumpsCount = 1;
    public Transform groundChecker;
    public LayerMask groundLayer;
    public float groundRadius = 1f;
    private bool isJumping = false;

    private InputSystem_Actions controls;
    private void Awake()
    {
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {

        Movement();
        Jump();
        CheckIfGrounded();
    }


    private void Jump()
    {
        if (controls.Player.Jump.WasPressedThisFrame())
        {
            if (availableJumpsCount >= 1) 
            {
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, jumpHeight);
                availableJumpsCount--;
                isJumping = true;
            }
        }
    }

    private void Movement()
    {
        Vector2 movDir = controls.Player.Move.ReadValue<Vector2>();
        transform.Translate(movDir.x * Time.deltaTime * speed, 0, 0);
    }
    private void CheckIfGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundLayer);

        if (isGrounded == true && isJumping == false)
        {
            availableJumpsCount = 1;
            isJumping = false;
        }
    }
}
