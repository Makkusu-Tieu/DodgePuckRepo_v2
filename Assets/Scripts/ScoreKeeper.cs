using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI highScoreText;
    public int scoreValue;
    public int highScoreValue;
    
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        highScoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }

    public void UpdateScore()
    {
        //scoreValue += 5;
        scoreText.text = "Score: " + scoreValue. ToString();
    }

    public void UpdateHighScore()
    {
        if (scoreValue > highScoreValue)
        {
            highScoreValue = scoreValue;
            highScoreText.text = "High Score: " + highScoreValue. ToString();
        }
    }
}
