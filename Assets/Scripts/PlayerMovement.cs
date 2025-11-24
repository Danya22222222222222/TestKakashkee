using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float smoothTimeGround = 0.05f;
    public float smoothTimeAir = 0.15f;

    [Header("Jump")]
    public float jumpForce = 7f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.15f;
    public LayerMask groundLayer; // €кщо 0 в ≥нспектор≥ Ч буде зам≥нено на "вс≥ шари" у Awake

    [Header("Debug")]
    public bool debugLogs = false;

    Rigidbody2D rb;
    Collider2D col;

    float inputX;
    float velXSmoothing;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // —пробувати знайти Collider2D на цьому об'Їкт≥ або в доч≥рн≥х
        col = GetComponent<Collider2D>();
        if (col == null)
            col = GetComponentInChildren<Collider2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // якщо groundCheck не заданий Ч створити простий порожн≥й об'Їкт п≥д персонажем
        if (groundCheck == null)
        {
            GameObject go = new GameObject("GroundCheck");
            go.transform.SetParent(transform);
            go.transform.localPosition = new Vector3(0f, -0.6f, 0f);
            groundCheck = go.transform;
        }

        // якщо у ≥нспектор≥ поставили 0 (н≥чого) Ч використовуЇмо маску "вс≥ шари"
        if (groundLayer == 0)
            groundLayer = ~0;
    }

    void Update()
    {
        // ќтримуЇмо горизонтальний вв≥д (A/D, стр≥лки або ≥нш≥, налаштован≥ у Input Manager)
        inputX = Input.GetAxis("Horizontal");

        // ¬икористовуЇмо Input Manager кнопку "Jump" (за замовчуванн€м проб≥л) або можна налаштувати на W/стр≥лку вгору
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // ¬становлюЇмо вертикальну швидк≥сть дл€ однозначного стрибка
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            if (debugLogs) Debug.Log("PlayerMovement: Jump");
        }
    }

    void FixedUpdate()
    {
        float targetVelX = inputX * moveSpeed;
        float smoothTime = IsGrounded() ? smoothTimeGround : smoothTimeAir;

        float newVelX = Mathf.SmoothDamp(rb.velocity.x, targetVelX, ref velXSmoothing, smoothTime);

        rb.velocity = new Vector2(newVelX, rb.velocity.y);

        if (debugLogs) Debug.Log($"FixedUpdate: inputX={inputX:F2} targetVelX={targetVelX:F2} newVelX={newVelX:F2}");
    }

    bool IsGrounded()
    {
        if (groundCheck == null) return false;

        // «ахищаЇмос€, €кщо колайдера немаЇ (не помил€тис€ при старт≥)
        if (col == null)
        {
            col = GetComponent<Collider2D>();
            if (col == null)
                col = GetComponentInChildren<Collider2D>();
        }

        Collider2D[] hits = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, groundLayer);
        foreach (var hit in hits)
        {
            if (hit == null) continue;
            if (hit == col) continue;      // ≥гнорувати власний колайдер
            if (hit.isTrigger) continue;  // ≥гнорувати тригери
            return true;
        }
        return false;
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}