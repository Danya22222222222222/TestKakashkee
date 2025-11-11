using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;               // Максимальна горизонтальна швидкість
    public float smoothTimeGround = 0.05f;     // Час згладжування на землі (менше = швидше реагує)
    public float smoothTimeAir = 0.15f;        // Час згладжування в повітрі (більше = інерція)

    [Header("Jump")]
    public float jumpForce = 7f;               // Сила стрибка

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.15f;
    public LayerMask groundLayer;

    [Header("Debug")]
    public bool debugLogs = false;

    Rigidbody2D rb;
    Collider2D col;

    float inputX;
    float velXSmoothing;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (groundCheck == null)
        {
            GameObject go = new GameObject("GroundCheck");
            go.transform.parent = transform;
            go.transform.localPosition = new Vector3(0f, -0.6f, 0f);
            groundCheck = go.transform;
        }

        if (groundLayer == 0)
            groundLayer = ~0; // всі шари за замовчуванням
    }

    void Update()
    {
        // Підтримуються клавіші A/D або стрілки для руху по горизонталі
        inputX = Input.GetAxis("Horizontal"); // від -1 до 1

        // Стрибок — W або стрілка вгору
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
        {
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

        // Use OverlapCircleAll and ignore player's own collider to avoid detecting self
        Collider2D[] hits = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, groundLayer);
        foreach (var hit in hits)
        {
            if (hit == null) continue;
            if (hit == col) continue; // ignore own collider
            if (hit.isTrigger) continue; // ignore triggers
            return true;
        }
        return false;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}
