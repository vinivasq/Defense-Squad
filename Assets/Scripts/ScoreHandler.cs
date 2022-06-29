using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    int score;

    public void UpdateScore (int amountToIncrease)
    {
        score += amountToIncrease;
        Debug.Log($"Your Score: {score} ");
    }


}
