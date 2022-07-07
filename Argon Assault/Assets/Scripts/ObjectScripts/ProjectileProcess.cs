using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProcess : MonoBehaviour
{
    [Header("Laser Projectile Settings")]
    [SerializeField] private GameObject[] laserObjects;

    [Header("Check State")]
    public bool isFiring = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFiring();
    }

    private void ProcessFiring() 
    {
        if (isFiring)
        {
            EnableLaserObjects();
            
        }

        else if (!isFiring)
        {
            DisableLaserObjects();
        }
    }

    private void EnableLaserObjects() 
    {
        foreach (GameObject laser in laserObjects) 
        {
            var laserParticles = laser.GetComponent<ParticleSystem>().emission;
            laserParticles.enabled = true;
            StartCoroutine(ChangeFiringState());
        }
    }

    private void DisableLaserObjects() 
    {
        foreach (GameObject laser in laserObjects) 
        {
            var laserParticles = laser.GetComponent<ParticleSystem>().emission;
            laserParticles.enabled = false;
        }
    }

    private IEnumerator ChangeFiringState() 
    {
        yield return new WaitForSeconds(0.2f);
        isFiring = false;
    }

}
