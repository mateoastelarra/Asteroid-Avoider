using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
