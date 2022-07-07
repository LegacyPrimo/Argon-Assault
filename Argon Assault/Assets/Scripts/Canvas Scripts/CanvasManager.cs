using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        
    }


    // Update is called once per frame
    void Update()
    {
        ShowText();
    }

    private void ShowText() 
    {
        scoreText.text = scoreManager.GetScore().ToString();
    }
}
