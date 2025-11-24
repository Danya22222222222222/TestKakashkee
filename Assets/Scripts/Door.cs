using UnityEngine;

public class Door : MonoBehaviour
{
    public Collider2D doorCollider;      // перетягни Collider (наприклад BoxCollider2D)
    public SpriteRenderer doorSprite;    // перетягни SpriteRenderer (щоб сховати)
    public float openMoveY = 2f;         // на скільки підняти при відкритті
    public float openTime = 0.5f;

    bool isOpen = false;

    void Start()
    {
        if (doorCollider == null) doorCollider = GetComponent<Collider2D>();
        if (doorSprite == null) doorSprite = GetComponent<SpriteRenderer>();
    }

    public void OpenDoor()
    {
        if (isOpen) return;
        isOpen = true;

        // Найпростіше: вимикаємо колайдер та запускаємо підняття/зникнення
        if (doorCollider != null) doorCollider.enabled = false;

      
        else
            gameObject.SetActive(false);
    }

}
