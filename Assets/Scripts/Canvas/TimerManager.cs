using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public FrontManager frontManager;

    private float currentTime;
    private float totalTime = 60f;


    void Update()
    {

        if (frontManager.getPlaying())
            currentTime -= Time.deltaTime;

        if (currentTime <= 0 & frontManager.getPlaying())
        {
            currentTime = 0;
            frontManager.endGame();
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        if (currentTime >= 0)
            timerText.text = "Seconds left: " + Mathf.Round(currentTime).ToString();
        else
            timerText.text = "Time finished!";
    }

    public void resetTimer(float time)
    {
        currentTime = time;
        totalTime = time;
    }

}
