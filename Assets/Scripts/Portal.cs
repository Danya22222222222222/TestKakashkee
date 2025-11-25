using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private LevelLoader levelLoader;

    void Start()
    {
        // Знаходимо об'єкт, на якому висить LevelLoader (Scene Manager)
        // Припускаємо, що LevelLoader висить на об'єкті з тегом "GameController" або "SceneManager"
        // Або просто шукаємо його в сцені
        levelLoader = FindObjectOfType<LevelLoader>();

        if (levelLoader == null)
        {
            Debug.LogError("LevelLoader не знайдено в сцені! Переходи не працюватимуть.");
        }
    }

    // Метод спрацьовує, коли об'єкт з Collider заходить у тригер (портал)
    private void OnTriggerEnter2D(Collider2D other) // Використовуйте OnTriggerEnter для 3D
    {
        // Перевіряємо, чи це саме гравець торкнувся порталу (за тегом)
        if (other.CompareTag("Player"))
        {
            // Викликаємо метод завантаження наступного рівня
            if (levelLoader != null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            }
        }
    }

    // Якщо у вас 3D-гра, використовуйте цей метод:
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (levelLoader != null)
            {
                levelLoader.LoadNextLevel();
            }
        }
    }
    */
}