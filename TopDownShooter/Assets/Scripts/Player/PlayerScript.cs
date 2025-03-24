using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float health = 50f;
    public HPManager hpManager;  // Reference to HPManager to update UI
    public PlayerMovement movement;
    // This method is called to reduce health when the player takes damage

    void Start()
    {
        // Ensure HPManager is assigned (you can assign this in the Inspector if public)
        if (hpManager == null)
        {
            hpManager = FindObjectOfType<HPManager>();  // Find the HPManager in the scene if not assigned
            
        }
        if (movement)
        {
            movement = FindObjectOfType<PlayerMovement>();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);
        if (hpManager != null)
        {
            hpManager.SubtractHP(damage);  // Call AddScore which updates HP on UI
        }
        if (health <= 0)
        {
            // Call death method or handle player death
            Die();
        }
    }

    public void AddHealth(float hp) 
    {
        if (health < 50) 
        {
         
            health += hp;
            if (hpManager != null)
            {
                hpManager.AddHp((int)hp);  // Call AddScore which updates HP on UI
            }

        }

    }
    public void AddSpeedPowerUp(float speedDuration)
    {
        movement.DoubleMovement(speedDuration);
    }

    void Die()
    {
        // Assuming this is in your game over or end game method
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();  // Find the ScoreManager instance
        if (scoreManager != null)
        {
            scoreManager.SaveScore();  // Save the final score when the game ends
        }
        // Handle player death (e.g., play death animation, restart game, etc.)
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerAim>().enabled = false;
        Debug.Log("Player Died");
        SceneManager.LoadScene("Start");

    }
}
