using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public int damage = 10; // Amount of damage to inflict on player

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") // Check if collided object is a player
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>(); // Get the PlayerHealth component of the collided player

            if (playerHealth != null) // Make sure the player has a PlayerHealth component
            {
                playerHealth.TakeDamage(damage); // Inflict damage on the collided player
            }
        }
    }
}