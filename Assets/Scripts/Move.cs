using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //MoneyTest
            gMan gMan= FindObjectOfType<gMan>();
            gMan.mnChange(5);
            velocity = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            velocity = new Vector3(velocity.x, velocity.y, 0);
            if (velocity.x < -8.5f) velocity.x = -8.5f;
            if (velocity.x > 23.5f) velocity.x = 23.5f;
            if (velocity.y < -10.5f) velocity.y = -10.5f;
            if (velocity.x < 1)
            {
                if (velocity.y > 5.5f) velocity.y = 5.5f;
            }
            else
            {
                if (velocity.y > 7)
                {
                    velocity.y = 7;
                }
                if (velocity.x < 1 && velocity.y > 5.5) velocity.x = 1;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, velocity, 5f * Time.deltaTime);
    }
}
