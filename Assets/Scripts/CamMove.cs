using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float camPositionSpeed = 5f;
    public float shakeAmount = 0.01f;

    private Vector3 lastPlayerPosition;
    private bool isMoving;

    void Start()
    {
        lastPlayerPosition = playerTransform.position;
    }

    void FixedUpdate()
    {
        Vector3 newCamPosition = new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, offset.z);

        // Check if the player is moving
        isMoving = (playerTransform.position != lastPlayerPosition);
        lastPlayerPosition = playerTransform.position;

        if (isMoving)
        {
            // Apply a small shake effect
            newCamPosition += new Vector3(Random.Range(-shakeAmount, shakeAmount), Random.Range(-shakeAmount, shakeAmount), 0);
        }

        transform.position = Vector3.Lerp(transform.position, newCamPosition, camPositionSpeed * Time.deltaTime);
    }
}