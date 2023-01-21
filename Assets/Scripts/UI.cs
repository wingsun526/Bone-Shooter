using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject titleMenu;
    [SerializeField] private GameObject endMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateScoreText();
    }

    public void setTitleMenuActive()
    {
        endMenu.SetActive(false);
        titleMenu.SetActive(true);
    }
    
    public void setEndMenuActive()
    {
        titleMenu.SetActive(false);
        endMenu.SetActive(true);
    }
    private void updateScoreText()
    {
        scoreText.text = ScoreManager.instance.GetScore().ToString();
    }
    
    public void GoBackToMainMenu()
    {
        
    }
}
