using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrontManager : MonoBehaviour
{
    public TextMeshProUGUI frontText;
    public PlateSpawner spawner;
    public ScoreManager scoreManager;
    public TimerManager timerManager;
    public float totalSeconds;

    private bool isPlaying;
    void Start()
    {
        setStartText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Starting game");
            startGame();
        }
        
    }
    public void setStartText()
    {
        frontText.text = "HI!\r\nIf you are ready to play, \r\npick up both guns with the grip buttons and \r\npress the space key to start.\r\n\r\nAlso, \r\nyou can do the peace sign with the primary buttons. ";
    }

    public void setEndText()
    {
        frontText.text = "The game has finished!\r\nIf you want to play again, press the space key again.";
    }
    public void startGame()
    {
        timerManager.resetTimer(totalSeconds);
        gameObject.SetActive(false);
        frontText.text = "";
        setPlaying(true);
        spawner.setSpawn(true);
        scoreManager.setScore(0);
        
    }

    public void endGame()
    {
        gameObject.SetActive(true); 
        setPlaying(false);
        spawner.setSpawn(false);
        setEndText();

    }
    public void setPlaying(bool playing)
    {
        isPlaying = playing;
        print("IsPlaying =" + isPlaying);
    }
    
    public bool getPlaying()
    {
        return isPlaying;
    }
}
