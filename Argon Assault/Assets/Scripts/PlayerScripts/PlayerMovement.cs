using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Settings")]
    private Vector3 input;
    [Tooltip("The Amount of Speed Given to the Player")][SerializeField] private float playerSpeed;

    [Header("Movement Clamp Settings")]
    [Tooltip("To Clamp the Movement of the Player Around the Camera")] [SerializeField] private float clampPosition;

    [Header("Rotation Settings")]
    [SerializeField] private float positionPitchFactor;
    [SerializeField] private float controlThrowFactor;
    [SerializeField] private float positionYawFactor;
    [SerializeField] private float controlRollFactor;

    [Header("Explosion Particle Effect")]
    [SerializeField] private ParticleSystem explosionParticlesEffect;

    private ProjectileProcess projectileProcess;

    // Start is called before the first frame update
    void Start()
    {
        projectileProcess = GetComponent<ProjectileProcess>();
    }

    private void Update()
    {
        RotateUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveUpdate();
    }


    #region Input Action Broadcast Methods
    private void OnMove(InputValue value) 
    {
        input = value.Get<Vector3>();
    }

    private void OnFire(InputValue value) 
    {
        if (projectileProcess != null) 
        {
            projectileProcess.isFiring = value.isPressed;
        }
    }
    #endregion

    #region Movement and Transform Update Methods
    private void MoveUpdate() 
    {
        Vector3 deltaMove = input * playerSpeed * Time.fixedDeltaTime;
        Vector3 newPosition = new Vector3();

        newPosition.x = Mathf.Clamp(transform.localPosition.x + deltaMove.x, -clampPosition, clampPosition);
        newPosition.y = Mathf.Clamp(transform.localPosition.y + deltaMove.y, -clampPosition, clampPosition);
        newPosition.z = Mathf.Clamp(transform.localPosition.z + deltaMove.z, -clampPosition, clampPosition);

        transform.localPosition = newPosition;
    }

    private void RotateUpdate() 
    {
        //Calculate Pitch Position (When The Jet is going Upward or Downward)
        float pitchPosition = transform.localPosition.y * positionPitchFactor;
        float pitchControl = input.y * controlThrowFactor;

        //Calculate Yaw Position (To smoothen out Jet Turning)
        float yawPosition = transform.localPosition.x * positionYawFactor;

        //Calculate Roll Control (When the Jet is Going Sideways)
        float rollControl = input.x * controlRollFactor;

        //Combine the Previous Calculations and Re-Initialize Variables
        float pitch = pitchPosition + pitchControl;
        float yaw = yawPosition;
        float roll = rollControl;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    #endregion

    public void EnableExplosion() 
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<BoxCollider>().enabled = false;
        explosionParticlesEffect.Play();
    }
}
