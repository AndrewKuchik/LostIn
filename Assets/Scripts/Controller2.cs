using UnityEngine;
using UnityEngine.InputSystem;

public class Controller2 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 10f;
    public int availableJumpsCount = 1;
    public Transform groundChecker;
    public LayerMask groundLayer;
    public float groundRadius = 1f;

    private bool isJumping = false;
    private InputSystem_Actions controls;
    private Rigidbody2D rb;

    private void Awake()
    {
        controls = new InputSystem_Actions();
        rb = GetComponent<Rigidbody2D>(); // Кэшируем Rigidbody2D
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
        // Проверяем нажатие на пробел или клавишу "W"
        if (controls.Player.Jump.WasPressedThisFrame() || Keyboard.current.wKey.wasPressedThisFrame)
        {
            if (availableJumpsCount >= 1)
            {
                // Используем AddForce для прыжка
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Сбрасываем вертикальную скорость перед прыжком
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
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

        if (isGrounded)
        {
            availableJumpsCount = 1; // Сбрасываем количество прыжков
            isJumping = false; // Сбрасываем флаг прыжка
        }
    }
}