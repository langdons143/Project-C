using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public static GameTimer instance;

    public float timeRemaining = 60f;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;

    // Final score text
    public TextMeshProUGUI finalScoreText;

    public bool gameEnded = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateTimer();
    }

    private void Update()
    {
        if (!gameEnded)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                EndGame();
            }

            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
    }

    private void EndGame()
    {
        gameEnded = true;

        // Display the player's final score
        finalScoreText.text = "Final Score: " + ScoreManager.instance.score;

        gameOverPanel.SetActive(true);

        Debug.Log("Time's Up! Game Over!");
    }
}