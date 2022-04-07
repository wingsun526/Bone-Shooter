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


    
    public void OnScoreChange(int val)
    {
        scoreText.ChangeScore(val);
    }
    public void ScreenShake()
    {
        cameraManager.PlayScreenShake();
    }

}
