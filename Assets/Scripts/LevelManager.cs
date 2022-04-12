using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu Scene");
    }
    
    public void LoadMainScene()
    {
        scoreManager.ResetScore();
        SceneManager.LoadScene("Main Scene");
    }
    
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over Scene");
    }
}
