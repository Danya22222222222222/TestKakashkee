using UnityEngine;

public class Door : MonoBehaviour
{
    public Collider2D doorCollider;      // перет€гни Collider (наприклад BoxCollider2D)
    public SpriteRenderer doorSprite;    // перет€гни SpriteRenderer (щоб сховати)
    public float openMoveY = 2f;         // на ск≥льки п≥дн€ти при в≥дкритт≥
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

        // Ќайпрост≥ше: вимикаЇмо колайдер та запускаЇмо п≥дн€тт€/зникненн€
        if (doorCollider != null) doorCollider.enabled = false;

        // якщо хочеш просто зникнути:
        if (doorSprite != null)
            StartCoroutine(FadeOutOrMove());
        else
            gameObject.SetActive(false);
    }

    System.Collections.IEnumerator FadeOutOrMove()
    {
        // приклад: п≥дн€ти вниз->вгору плавно
        Vector3 start = transform.position;
        Vector3 target = start + new Vector3(0, openMoveY, 0);
        float t = 0;
        while (t < openTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(start, target, t / openTime);
            yield return null;
        }
        // п≥сл€ п≥дн€тт€ можна ≥ зовс≥м сховати спрайт
        if (doorSprite != null) doorSprite.enabled = false;
    }
}
