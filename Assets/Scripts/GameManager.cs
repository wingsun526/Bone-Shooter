using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(cameraManager.gameObject);
            return;
        }
        instance = this;
        
        
    }

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CameraManager cameraManager;
    //[SerializeField] private ScoreManager scoreManager;
    [SerializeField] private WaveSpawner waveSpawner;
    [SerializeField] private ParticleSystemManager particleSystemManager;
    [SerializeField] private UI theUI;
    [SerializeField] private Animator menuAnimator;
    
    private ScoreManager scoreManager;
    private bool gameIsActive = false;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void StartGame()// used by play button
    {
        gameIsActive = true;
        waveSpawner.StartSpawning();
        menuAnimator.SetBool("hideMenu", true);
        scoreManager.ResetScore();
    }
    
    public void EndGame()
    {
        gameIsActive = false;
        menuAnimator.SetBool("hideMenu", false);
        theUI.setEndMenuActive();
        waveSpawner.Reset();
    }
    public void setGameActive(bool toPause)
    {
        gameIsActive = toPause;
    }
    public bool IsGameActive()
    {
        return gameIsActive;
    }
    public void OnScoreChange(int val)
    {
        scoreManager.ChangeScore(val);
    }
    public void ScreenShake()
    {
        cameraManager.PlayScreenShake();
    }

    public PlayerMovement GetPlayerMovement()
    {
        return playerMovement;
    }
    
    
    
    // All about waveSpawner
    public void OnEnemyDestroy()
    {
        waveSpawner.OneLessEnemyOnScreen();
    }
    
    // Particle System
    public void OnEnemySpawnParticle(Vector3 newLocation)
    {
        particleSystemManager.FireEnemySpawnParticle(newLocation);
    }
}
