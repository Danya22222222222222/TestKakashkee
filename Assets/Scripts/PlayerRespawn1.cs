using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    // Спрацює, якщо на колючках стоїть галочка "Is Trigger"
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(">>> ТРИГЕР! Я зайшов у: " + other.gameObject.name + " | Тег: " + other.tag);

        if (other.CompareTag("Spike"))
        {
            Debug.Log("Смерть від тригера!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Спрацює, якщо галочки "Is Trigger" НЕМАЄ (про всяк випадок)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(">>> УДАР! Я вдарився об: " + collision.gameObject.name + " | Тег: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Смерть від удару!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}