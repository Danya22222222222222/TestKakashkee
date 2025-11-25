using UnityEngine;

public class CrystalFollow : MonoBehaviour
{
    public Transform playerHead;      // Сюди кинеш "точку голови"
    public Vector3 offset = new Vector3(0, 0.5f, 0); // Відступ над головою
    private bool isFollowing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Шукаємо точку голови на гравці
            playerHead = collision.transform.Find("HeadPoint");

            if (playerHead != null)
            {
                isFollowing = true;
                // Вимикаємо фізику, щоб не падало
                GetComponent<Rigidbody2D>().isKinematic = true;
                GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }

    void Update()
    {
        if (isFollowing && playerHead != null)
        {
            transform.position = playerHead.position + offset;
        }
    }
}
