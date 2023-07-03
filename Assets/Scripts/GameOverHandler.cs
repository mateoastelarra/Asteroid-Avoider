using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] ScoreHandler scoreHandler;
    [SerializeField] TextMeshProUGUI gameOverText;

    public void EndGame()
    {
        gameOverMenu.SetActive(true);

        SetScoreText();

        scoreHandler.gameObject.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    private void SetScoreText()
    {
        Debug.Log("perdiste");
        float finalScore = scoreHandler.GetScore();
        gameOverText.text = "GAME OVER. \n Your score is: " + finalScore.ToString();
    }

}
