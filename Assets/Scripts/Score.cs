using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Score instance;

    public Player GameOverScript;

    //Score
    public Text scoreText;
    public static int scoreCounter;
    public int highScore;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        if(scoreCounter > highScore)
        {
            highScore = scoreCounter;
        }
    }

    public void Restart()
    {
        GameOverScript.GameOver();
    }
}
