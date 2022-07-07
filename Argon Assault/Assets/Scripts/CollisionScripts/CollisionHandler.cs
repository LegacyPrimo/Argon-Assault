using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null) 
        {
            if (other.CompareTag("Terrain")) 
            {
                if (this.gameObject.CompareTag("Player")) 
                {
                    gameManager.RestartScene();
                }
            }
        }
    }
}
