using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScoreDisplay();
    }

    // Function to update the score value
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }

    public void setScore(int points)
    {
        score = points;
    }

    // Function to update the score text display
    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
