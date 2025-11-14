using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip pickupSfx; // опціонально

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // можна тут грати звук
        if (pickupSfx != null)
            AudioSource.PlayClipAtPoint(pickupSfx, transform.position);

        // повідомляєм менеджер
        if (QuestManager.Instance != null)
            QuestManager.Instance.CollectItem();

        // знищити предмет
        Destroy(gameObject);
    }
}
