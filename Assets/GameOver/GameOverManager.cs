using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Retry()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Update is called once per frame
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
