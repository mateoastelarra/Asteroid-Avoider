using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private ScoreHandler scoreHandler;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject asteroidSpawner;
    [SerializeField] private GameObject player;
    [SerializeField] private Button continueButton;

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

    public void ContinueButton()
    {
        AdManager.instance.ShowAd(this);

        continueButton.interactable = false;
    }

    public void ContinueGame()
    {
        gameOverMenu.SetActive(false);

        scoreHandler.UnpauseScore();

        asteroidSpawner.SetActive(true);

        player.transform.position = Vector3.zero;
        player.SetActive(true);
    }

}
