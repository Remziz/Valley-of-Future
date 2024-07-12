using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject player;
    private Vector3 velocity = Vector3.zero;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            velocity = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            velocity = new Vector3(velocity.x, velocity.y, 0);
        }
        player.transform.position = Vector3.MoveTowards(player.transform.position, velocity, 5f * Time.deltaTime);
    }
}
