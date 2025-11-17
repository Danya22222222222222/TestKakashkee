using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void StartLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    
    public void GoToFinal()
    {
        SceneManager.LoadScene("FinalScene");
    }
}
