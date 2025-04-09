using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Controller1 : MonoBehaviour
{
    public float speed = 5f;
    public float maxSpeed = 5f;
    public float jumpHeight = 10f;
    private int availableJumpsCount = 1;
    public int maxAvailableJumpsCount = 2;

    public Transform groundChecker;
    public LayerMask groundLayer;
    public float groundRadius = 1f;
    private bool isJumping = false;

    private InputSystem_Actions controls;
    Rigidbody2D rb;
    SpriteRenderer _renderer;

    public float interractionRadius = 2f;
    public LayerMask lampLayer;

    public bool canJump = true;
    
    public Animator animator;
    bool jump = false;
    
    public UnityEvent OnLandEvent;

  
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new InputSystem_Actions();
        availableJumpsCount = maxAvailableJumpsCount;
        _renderer = GetComponent<SpriteRenderer>();

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
        ToggleLamp();
        
        
    }


    private void Jump()
    {
        if (canJump)
        {
            if (controls.Player.Jump.WasPressedThisFrame() || Keyboard.current.wKey.wasPressedThisFrame)
            {
                animator.SetBool("is_jumping", true);
                
                if (availableJumpsCount > 0) 
                {
                    GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, jumpHeight);
                    availableJumpsCount--;
                    isJumping = true;
                }
            }
        }
        
    }
    public void KomandaKuruIzsauktKadEsamPiezem()
    {
        animator.SetBool("is_jumping", false);
    }
    private void Movement()
    {
        
        
        Vector2 movDir = controls.Player.Move.ReadValue<Vector2>();
        if (movDir.x < 0)
        {
            _renderer.flipX = true;
            
        }
        else if (movDir.x > 0)
        {
            _renderer.flipX = false;
        }
        
        transform.Translate(movDir.x * Time.deltaTime * speed, 0, 0);
        animator.SetFloat("speed", Mathf.Abs(Movement));
    }
    
    
    private void CheckIfGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundLayer);

        if (isGrounded == true && rb.linearVelocityY <= 0.01f)
        {
           
            availableJumpsCount = maxAvailableJumpsCount;
            isJumping = false;
        }
    }

    private void ToggleLamp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D lampCollider = Physics2D.OverlapCircle(transform.position, interractionRadius, lampLayer);

            Debug.Log(lampCollider);
            if (lampCollider != null)
            {
                LampController lamp = lampCollider.GetComponent<LampController>();
                if (lamp != null)
                {
                    lamp.ToggleLamp();
                    transform.GetComponent<PlayerHP>().healPlayer(100);
                }
            }
        }
    }
}
