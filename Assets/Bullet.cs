using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Adjustable bullet speed
    public float lifetime = 2f; // Time before bullet is destroyed

    private void Start()
    {
        // Set the bullet's velocity based on the speed variable
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed; // Use the bullet's up direction for movement

        Destroy(gameObject, lifetime); // Destroy bullet after a certain time
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collisions here (e.g., destroy bullet on hit)
        
        Destroy(gameObject); // Destroy bullet on hit

    }
}
