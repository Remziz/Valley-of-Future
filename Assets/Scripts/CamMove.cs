using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float camPositionSpeed = 5f;
    public float shakeAmount = 0.01f;
    public float shakeSmoothness = 0.1f;

    private Vector3 lastPlayerPosition;
    private bool isMoving;
    private Camera cam;
    private float shakeTimer;

    void Start()
    {
        lastPlayerPosition = playerTransform.position;
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        Vector3 newCamPosition = new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, offset.z);

        // Check if the player is moving
        isMoving = (playerTransform.position != lastPlayerPosition);
        lastPlayerPosition = playerTransform.position;

        if (isMoving)
        {
            // Apply a small shake effect using Perlin noise for smoother motion
            shakeTimer += Time.deltaTime;
            float shakeX = Mathf.PerlinNoise(shakeTimer, 0f) * 2 - 1;
            float shakeY = Mathf.PerlinNoise(0f, shakeTimer) * 2 - 1;
            newCamPosition += new Vector3(shakeX * shakeAmount, shakeY * shakeAmount, 0);
        }
        else
        {
            shakeTimer = 0;
        }

        transform.position = Vector3.Lerp(transform.position, newCamPosition, camPositionSpeed * Time.deltaTime);
    }
private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            for (int i = 0; i < hit.Length; i++)
            {
                Debug.Log(hit[i].collider.name);
                if (hit[i].collider.name == "Pause")
                {
                    break;
                }
                else if (hit[i].collider.name == "menu")
                {
                    break;
                }
                else
                {
                    string name = hit[i].collider.name;
                    if (name.Contains("fland")) GameObject.Find(name).GetComponent<Cell>().MouseDown();
                    break;
                }
            }
        }
    }
}