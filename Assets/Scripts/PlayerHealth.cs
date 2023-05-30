using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;  // Player'sHealth

    // Method to take damage
    public void TakeDamage(float amount)
    {
        health -= amount;

        // If ZombieHealth goes below 0, player dies
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
