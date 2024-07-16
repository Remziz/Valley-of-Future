using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 5.0f;
    public float stoppingDistance = 0.01f; // Adjust this value to control how close the player needs to be to stop
    private Vector3 targetPosition;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
        else if (Input.GetMouseButtonDown(1)) GameObject.Find("sma").gameObject.GetComponent<MemberActiveMenu>().Sbros_menu();
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
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}