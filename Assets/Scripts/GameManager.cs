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


    public void ScreenShake()
    {
        cameraManager.Play();
    }

}
