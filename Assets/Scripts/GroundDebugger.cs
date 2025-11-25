using UnityEngine;

public class GroundDebugger : MonoBehaviour
{
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    void Update()
    {
        // Малюємо червону сферу, щоб бачити радіус
        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (collider != null)
        {
            //Debug.Log($"<color=green>БАЧУ ЗЕМЛЮ: {collider.gameObject.name} (Layer: {LayerMask.LayerToName(collider.gameObject.layer)})</color>");
        }
        else
        {
            //Debug.Log("<color=red>У ПОВІТРІ (Нічого не торкаюсь)</color>");
        }
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}