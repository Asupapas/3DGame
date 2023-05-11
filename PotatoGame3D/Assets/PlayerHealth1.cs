using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth1 : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of player
    public int currentHealth; // Current health of player

    void Start()
    {
        currentHealth = maxHealth; // Initialize player's health to maximum at start of game
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Subtract damage from player's current health

        if (currentHealth <= 0)
        {
            Die(); // Player has died
        }
    }

    void Die()
    {
         void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1f;
        }
    }
}