using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 5.0f;
    public float stoppingDistance = 0.01f;
    private Vector3 targetPosition;
    public GameObject Menu;
    private Rigidbody2D rb;

    public Sprite[] leftAnimationSprites; // Array of sprites for left movement animation
    public Sprite[] rightAnimationSprites; // Array of sprites for right movement animation
    private SpriteRenderer spriteRenderer;
    private float frameRate = 0.2f; // Time per frame
    private float nextFrameTime = 0f;
    private int currentFrameIndex = 0;
    private bool isAnimating = false;
    private bool isMovingLeft = false;

    public AudioClip footstepSound; // Sound clip for footsteps
    private AudioSource audioSource;

    public ParticleSystem dirtParticleSystem; // Reference to the particle system

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetPosition = transform.position;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = footstepSound;
        audioSource.loop = true;

        // Ensure the particle system is disabled initially
        if (dirtParticleSystem != null)
        {
            dirtParticleSystem.Stop();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
            Menu.GetComponent<MemberActiveMenu>().Sbros_menu();
        }

        if (Time.time > nextFrameTime && isAnimating)
        {
            currentFrameIndex = (currentFrameIndex + 1) % 3; // Cycle through 0, 1, 2
            nextFrameTime = Time.time + frameRate;
            if (isMovingLeft)
            {
                spriteRenderer.sprite = leftAnimationSprites[currentFrameIndex];
            }
            else
            {
                spriteRenderer.sprite = rightAnimationSprites[currentFrameIndex];
            }
        }
    }

    void FixedUpdate()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);

        if (distanceToTarget > stoppingDistance)
        {
            Vector2 direction = (targetPosition - transform.position).normalized;
            rb.velocity = direction * speed;
            isAnimating = true;
            isMovingLeft = direction.x < 0;

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            // Emit dirt particles when moving
            if (dirtParticleSystem != null)
            {
                dirtParticleSystem.Play();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            isAnimating = false;
            currentFrameIndex = 0; // Reset to first frame
            audioSource.Stop();

            // Stop emitting dirt particles when not moving
            if (dirtParticleSystem != null)
            {
                dirtParticleSystem.Stop();
            }
        }
    }
}