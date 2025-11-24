using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Завантажує наступну сцену у порядку Build Settings
    public void LoadNextLevel()
    {
        // Отримуємо індекс поточної сцени
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Визначаємо індекс наступної сцени
        int nextSceneIndex = currentSceneIndex + 1;

        // Перевіряємо, чи існує наступна сцена (щоб не вийти за межі)
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Якщо це останній рівень, повертаємося до головного меню (індекс 0)
            Debug.Log("Всі рівні пройдено. Повернення до Головного меню.");
            SceneManager.LoadScene(0);
        }
    }

    // Публічний метод для кнопок в меню (завантажує за фіксованим індексом)
    public void LoadLevelByIndex(int sceneIndex)
    {
        if (sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError("Сцена з індексом " + sceneIndex + " не знайдена!");
        }
    }
}