using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 5;  // Amount of damage dealt by the zombie attack
    public float attackCooldown = .75f;  // Cooldown in seconds between attacks
    private float lastAttackTime = 0f;  // Time of the last attack

    // This method is triggered when another collider enters the attack area
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))  // Check if the collider belongs to the player
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {

                // Call a method on the player to apply damage
                other.gameObject.GetComponent<PlayerScript>().TakeDamage(damage);
                lastAttackTime = Time.time;
            }

        }
    }
}
