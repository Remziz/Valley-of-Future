using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float camPositionSpeed = 5f;
    public float shakeAmount = 0.01f;
    public float shakeSmoothness = 0.1f;
    public AudioClip gimn;

    private Vector3 lastPlayerPosition;
    private bool isMoving;
    private Camera cam;
    private float shakeTimer;
    RaycastHit2D hit;

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
            hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000);
            string name = hit.transform.name;
            if (name.Contains("fland") && !EventSystem.current.IsPointerOverGameObject()) GameObject.Find(name).GetComponent<Cell>().MouseDown();
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            GameObject.Find("sma").GetComponent<AudioSource>().clip = gimn;
        }
    }
}