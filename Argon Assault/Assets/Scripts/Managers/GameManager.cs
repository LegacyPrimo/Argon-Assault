using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerMovement player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        ManageSingleton();
    }

    private void ManageSingleton() 
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;

        if (instanceCount > 1) 
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

        else 
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void RestartScene() 
    {
        if (player != null) 
        {
            player.EnableExplosion();
        }

        StartCoroutine(DelaySceneLoad(SceneManager.GetActiveScene().name));

    }

    public void LoadNextScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(DelaySceneLoad(SceneManager.GetActiveScene().buildIndex.ToString() + 1));
    }

    private IEnumerator DelaySceneLoad(string sceneName) 
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
