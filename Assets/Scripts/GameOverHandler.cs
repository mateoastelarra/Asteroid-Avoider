using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] ScoreHandler scoreHandler;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] GameObject asteroidSpawner;
    [SerializeField] GameObject player;

    public void EndGame()
    {
        gameOverMenu.SetActive(true);

        SetScoreTextAndPauseScore();

        asteroidSpawner.SetActive(false);

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    private void SetScoreTextAndPauseScore()
    {
        float finalScore = scoreHandler.StopCountingAndGetScore();
        gameOverText.text = "GAME OVER. \n Your score is: " + finalScore.ToString();
    }

    public void Continue()
    {
        gameOverMenu.SetActive(false);
        scoreHandler.UnpauseScore();
        asteroidSpawner.SetActive(true);
        player.SetActive(true);
    }

}
