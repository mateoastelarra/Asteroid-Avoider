using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float scoreMultiplier = 10f;
    private float score = 0;
    private bool isPaused = false;

    void Start()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {
        if (isPaused){ return; }

        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public int StopCountingAndGetScore()
    {
        isPaused = true;

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    }

    public void UnpauseScore()
    {
        isPaused = false;
    }
}
