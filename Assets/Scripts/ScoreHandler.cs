using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float scoreMultiplier = 10f;
    private float score = 0;

    void Start()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {
        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.Floor(score).ToString();
    }

    public float GetScore()
    {
        return Mathf.Floor(score);
    }
}
