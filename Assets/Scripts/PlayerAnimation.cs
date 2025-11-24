using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Ця магія шукає Аніматор на дочірніх об'єктах (на твоєму чорті)
        // Тобі більше не треба нічого перетягувати вручну!
        anim = GetComponentInChildren<Animator>();

        if (anim == null)
        {
            Debug.LogError("Агов! На об'єкті 'Без назви' немає компонента Animator! Додай його.");
        }
    }

    void Update()
    {
        if (anim == null || rb == null) return;

        // Передаємо швидкість (Speed)
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        // Передаємо стрибок (IsJumping)
        // Якщо летимо вгору чи вниз швидше ніж 0.1 — значить стрибаємо
        bool isJumping = Mathf.Abs(rb.velocity.y) > 0.1f;
        anim.SetBool("IsJumping", isJumping);
    }
}