using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalFunctions
{
    public static void GlobalAddScore(int points)
    {
        ScoreManager scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(points);
        }
        else
        {
            Debug.LogWarning("ScoreManager not found in the scene. Cannot add score.");
        }
    }
}
