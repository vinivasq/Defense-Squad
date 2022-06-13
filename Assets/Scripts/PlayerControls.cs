using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float xAccel = 60f; 
    [SerializeField] float yAccel = 60f;
    [SerializeField] float xRange = 15f;
    [SerializeField] float yRange = 15f;

    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow *Time.deltaTime * xAccel;
        float yOffset = yThrow *Time.deltaTime * yAccel;
        float zOffset = 0;

        float xPosition = transform.localPosition.x + xOffset;
        float clampedxPos = Mathf.Clamp(xPosition, -xRange, xRange);

        float yPosition = transform.localPosition.y + yOffset;
        float clampedyPos = Mathf.Clamp(yPosition, -yRange, yRange);

        float zPosition = transform.localPosition.z + zOffset;

        transform.localPosition = new Vector3 (clampedxPos, clampedyPos, zPosition);



    }
}
