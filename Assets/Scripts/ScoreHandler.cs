using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    int score;
    TMP_Text scoreText;

    void Start() 
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "SCORE: 000000";   
    }

    public void UpdateScore (int amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = amountToIncrease.ToString();
        scoreText.text = $"SCORE: {score}";
    }


}
