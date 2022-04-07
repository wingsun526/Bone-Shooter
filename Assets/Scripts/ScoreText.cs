using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private int score = 0;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    public void ChangeScore(int val)
    {
        score += val;
    }
    public int GetScore()
    {
        return score;
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
    
    public void ResetScore()
    {
        score = 0;
    }
}
