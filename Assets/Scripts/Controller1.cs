using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Controller1 : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public float maxSpeed = 5f;
    public float jumpHeight = 10f;
    private int availableJumpsCount = 1;
    public int maxAvailableJumpsCount = 2;
    public Transform groundChecker;
    public LayerMask groundLayer;
    public float groundRadius = 1f;
    private bool isJumping = false;
    public bool canJump = true;
    private InputSystem_Actions controls;
    Rigidbody2D rb;
    SpriteRenderer _renderer;

    [Header("Interaction Settings")]
    public float interractionRadius = 2f;
    public LayerMask lampLayer;
    
    public Animator animator;
    bool jump = false;
    
    public UnityEvent OnLandEvent;
    
    
    [Header("Sound")]
    public AudioClip jumpSound;
    public AudioClip humanSound;
    public AudioClip torchSound;
    public AudioClip pickupSound;
    public AudioClip[] footstepSound;
    private AudioSource audioSource;


    [Header("UI Elements")]
    public int currentGold = 0;
    public TextMeshProUGUI GoldText;
    private PlayerHP playerHP;
    
    
  
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new InputSystem_Actions();
        availableJumpsCount = maxAvailableJumpsCount;
        _renderer = GetComponent<SpriteRenderer>();
        playerHP = GetComponent<PlayerHP>();
    }

    private void Start()
    {
        if(GoldText != null)
        {
            GoldText.text = currentGold.ToString();
        }
        
        audioSource = GetComponent<AudioSource>();
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
                    rb.linearVelocity = new Vector2(0, jumpHeight);
                    availableJumpsCount--;
                    isJumping = true;
                    Debug.Log(("Doing Jump SOund"));
                    audioSource.PlayOneShot(jumpSound);
                    audioSource.PlayOneShot(humanSound);
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

        if (movDir != Vector2.zero)
        {
            PlayRandomFootstep();
        }
        
        animator.SetFloat("speed", Mathf.Abs(movDir.x));
    }
    
    
    private void CheckIfGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundLayer);

        if (isGrounded == true && rb.linearVelocityY <= 0.01f)
        {
           
            availableJumpsCount = maxAvailableJumpsCount;
            isJumping = false;
            
            KomandaKuruIzsauktKadEsamPiezem();
        }
    }

    private void ToggleLamp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D lampCollider = Physics2D.OverlapCircle(transform.position, interractionRadius, lampLayer);

            // Debug.Log(lampCollider);
            if (lampCollider == null) return;
            
            LampController lamp = lampCollider.GetComponent<LampController>();
            if (lamp == null) return;
            
            if (!lamp.isActiveNow)
            {
                if (currentGold >= lamp.ActivatePrice)
                {
                    UpdateGold(-lamp.ActivatePrice);
                    audioSource.PlayOneShot(torchSound);
                    lamp.ToggleLamp();
                }
            }
            else
            {
                playerHP.healPlayer(100);
            }
        }
    }

    public void UpdateGold(int amount)
    {
        if (amount > 0)
        {
            audioSource.PlayOneShot(pickupSound);
        }
       
        
        currentGold += amount;
        if (GoldText != null)
        {
            GoldText.text = currentGold.ToString();
        }
    }


    private void PlayRandomFootstep()
    {
        if (footstepSound.Length == 0) 
            return;
        
        if(audioSource.isPlaying) 
            return;
        
        int random = Random.Range(0, footstepSound.Length);
        audioSource.pitch = Random.Range(0.75f, 1.25f);
        audioSource.PlayOneShot(footstepSound[random]);
    }
}
