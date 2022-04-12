using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    private bool youWin = false;
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score);
    }

    public void ChangeScore(int val)
    {
        score += val;
    }
    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
        youWin = false;
    }
    
    public void Win()
    {
        youWin = true;
    }
    
    public bool getYouWin()
    {
        return youWin;
    }
}
