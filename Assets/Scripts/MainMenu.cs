using UnityEngine;
using UnityEngine.SceneManagement; // Обязательно для работы со сценами

public class MainMenu : MonoBehaviour
{
    // Метод для кнопки "Играть"
    public void PlayGame()
    {
        
        // Загружает следующую сцену в списке Build Settings
        // Например, если Меню - это индекс 0, то Игра будет индекс 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Метод для кнопки "Выход"
    public void QuitGame()
    {
        Debug.Log("Игра закрылась!"); // Чтобы видеть проверку в редакторе Unity
        Application.Quit();
    }
}