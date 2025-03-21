using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPowerUp : MonoBehaviour
{
    PlayerScript playerScript;
    PlayerShooting PlayerShoot;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        PlayerShoot= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("HpDrop"))
            {
                HpStrategy hpStrategy = new HpStrategy();
                playerScript.AddHealth(hpStrategy.GetPowerUp()); 
            }
            else if (gameObject.CompareTag("SpeedDrop"))
            {
                SpeedStrategy speedStrategy = new SpeedStrategy();
                playerScript.AddSpeedPowerUp(speedStrategy.GetPowerUp()); 

            }
            else if (gameObject.CompareTag("FireRateDrop"))
            {
                FireRateStrategy fireRate = new FireRateStrategy();
               PlayerShoot.AddFireRate(fireRate.GetPowerUp()); 


            }
            Destroy(gameObject);
        }

    }
}
