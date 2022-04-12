using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI statusText;
    // Start is called before the first frame update
    //private ScoreManager scoreManager;
    private void Awake()
    {
        //scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Start()
    {
        scoreText.text = ScoreManager.instance.GetScore().ToString();
        winOrLose();
    }

    private void winOrLose()
    {
        if(ScoreManager.instance.getYouWin())
        {
            statusText.text = "You Win";
        }
        else
        {
            statusText.text = "You Lose";
        }
    }
        
}
