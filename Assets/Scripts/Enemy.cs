using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Check if the thing we hit is a Projectile
        if (other.CompareTag("Projectile"))
        {
            FindObjectOfType<ScoreManager>().AddScore(5);
            Destroy(other.gameObject); // Destroy the bullet
            Destroy(gameObject);       // Destroy this enemy
            return;                    // Exit the function so we don't check for the player
        }

        // 2. Check if the thing we hit is the Player
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject); // Destroy the enemy after it hits the player
        }
    }

    void Update()
    {
        // Cleanup if the enemy flies off screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}