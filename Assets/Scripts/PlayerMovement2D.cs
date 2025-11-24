using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [Header("Настройки")]
    public float speed = 5f;
    public float jumpForce = 10f;

    [Header("Земля (Ground Check)")]
    public Transform groundCheck;     // Точка в ногах
    public float checkRadius = 0.2f;  // Радиус круга проверки
    public LayerMask groundLayer;     // Слой земли

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        // Получаем именно 2D компонент
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Проверка земли (используем OverlapCircle для 2D)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // 2. Управление (A/D или Стрелки)
        moveInput = Input.GetAxis("Horizontal");

        // 3. Физическое движение
        // Мы меняем скорость по X, но оставляем Y как есть (чтобы работала гравитация)
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // 4. Поворот персонажа (Покращений)
        // Ми беремо поточний розмір, щоб не ламати налаштування
        Vector3 currentScale = transform.localScale;

        if (moveInput > 0)
        {
            // Дивимося вправо (X додатній)
            currentScale.x = Mathf.Abs(currentScale.x);
            transform.localScale = currentScale;
        }
        else if (moveInput < 0)
        {
            // Дивимося вліво (X від'ємний)
            currentScale.x = -Mathf.Abs(currentScale.x);
            transform.localScale = currentScale;
        }

        // 5. Прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }

    // Цей метод малює коло в редакторі Unity, щоб ми бачили радіус перевірки
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}