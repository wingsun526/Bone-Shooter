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
    [SerializeField] private ScoreText scoreText;
    [SerializeField] private WaveSpawner waveSpawner;
    [SerializeField] private ParticleSystemManager particleSystemManager;


    
    public void OnScoreChange(int val)
    {
        scoreText.ChangeScore(val);
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
