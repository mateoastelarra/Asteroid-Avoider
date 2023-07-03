using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
