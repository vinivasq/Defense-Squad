using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header ("General Movemet Settings")]
    [Tooltip ("Speed factor for how fast the ship moves based uppon player input")]
    [SerializeField] float controlSpeed = 40f; 
    [Tooltip("Screen limits for how far the ship goes on the X axis ")]
    [SerializeField] float xRange = 26f;
    [Tooltip("Screen limits for how far the ship goes on the Y axis ")]
    [SerializeField] float yRange = 17f;

    [Header ("Ship Rotation Settings")]
    [Tooltip("Pitch factor based on the ship position")]
    [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("Pitch factor based on player input")]
    [SerializeField] float controlPitchFactor = -15f;
    [Tooltip("Yaw factor based on the ship position")]
    [SerializeField] float positionYawFactor = 2f;
    [Tooltip("Roll factor based on player input")]
    [SerializeField] float controlRollFactor = -15f;
    
    [Header ("Lasers Placeholder")]
    [SerializeField] GameObject[] lasers;

    float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotaion();
        ProcessShooting();

    }

    void ProcessRotaion ()
    {
        float pitchFromPosition = transform.localPosition.y * positionPitchFactor;
        float pitchFromControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchFromPosition + pitchFromControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float zOffset = 0;

        float xPosition = transform.localPosition.x + xOffset;
        float clampedxPos = Mathf.Clamp(xPosition, -xRange, xRange);

        float yPosition = transform.localPosition.y + yOffset;
        float clampedyPos = Mathf.Clamp(yPosition, -yRange, yRange);

        float zPosition = transform.localPosition.z + zOffset;

        transform.localPosition = new Vector3(clampedxPos, clampedyPos, zPosition);
    }

    void ProcessShooting ()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActvie(true);
        }
        else
        {
            SetLasersActvie(false);
        }
    }

    void SetLasersActvie(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;

        }
    }

}
