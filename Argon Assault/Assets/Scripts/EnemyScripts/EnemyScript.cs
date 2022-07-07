using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyExplosionEffect;
    [SerializeField] private GameObject enemyHitEffect;
    [SerializeField] private float scoreToAdd;
    [SerializeField] private float lifeCounter = 3f;
    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }


    private void OnParticleCollision(GameObject other)
    {
        if (other != null) 
        {
            ProcessHit();

            if (lifeCounter == 0) 
            {
                OnDeath();
            }
            
        }   
    }

    private void ProcessHit() 
    {
        lifeCounter--;
        ProcessEnemyHitScore();
        Instantiate(enemyHitEffect, transform.position, Quaternion.identity);
    }

    private void OnDeath() 
    {
        Instantiate(enemyExplosionEffect, transform.position, Quaternion.identity);
        ProcessEnemyHitScore();
        Destroy(this.gameObject);
    }

    private void ProcessEnemyHitScore() 
    {
        scoreManager.AddScore(scoreToAdd);
    }
}
