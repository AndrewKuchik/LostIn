using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    private Vector2 moveInput;

   
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public int doubleJump = 1;

    private InputSystem_Actions controls;
    
    
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    private bool isJumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        ProcessMovement();
        ProcessJump();
    }

    private void FixedUpdate()
    {
        CheckIfGrounded();
    }

    private void ProcessMovement()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    private void ProcessJump()
    {
        if(controls.Player.Jump.WasPressedThisFrame())
        {
            if (doubleJump >= 1)
            {
                doubleJump--;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }
       
    }

    private void CheckIfGrounded()
    { 
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            doubleJump = 1;
            isJumping = false;
        }

        Debug.Log("Ģrounded - " + isGrounded);
    }
}
