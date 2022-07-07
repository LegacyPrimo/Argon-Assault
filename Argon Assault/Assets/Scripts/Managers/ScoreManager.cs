using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score;

    public float GetScore() 
    {
        return score;
    }

    public void AddScore(float addScore) 
    {
        score += addScore;
    }
}
