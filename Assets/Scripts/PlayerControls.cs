using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float xAccel = 60f; 
    [SerializeField] float yAccel = 60f;
    [SerializeField] float xRange = 15f;
    [SerializeField] float yRange = 13f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -15f;

    float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotaion();

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

        float xOffset = xThrow * Time.deltaTime * xAccel;
        float yOffset = yThrow * Time.deltaTime * yAccel;
        float zOffset = 0;

        float xPosition = transform.localPosition.x + xOffset;
        float clampedxPos = Mathf.Clamp(xPosition, -xRange, xRange);

        float yPosition = transform.localPosition.y + yOffset;
        float clampedyPos = Mathf.Clamp(yPosition, -yRange, yRange);

        float zPosition = transform.localPosition.z + zOffset;

        transform.localPosition = new Vector3(clampedxPos, clampedyPos, zPosition);
    }
}
