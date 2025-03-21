using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    IDropStrategy dropStrat;
    public Transform player;  
    public Animator animator;  

    public int enemyHP = 15;
    public bool isDead = false; // Prevents re-triggering animations after death

    
    
    public int attackRange = 1;  // Range at which the zombie will attack
    public float chaseRange = 1000f;
    

    private EnemyStateMachine currentState; // Tracks the active state
    private Pool pool;  // Reference to the object pool (if using pooling)

    public GameObject[] powerUpPrefabs;  
    private float dropChance = 0.5f; 

    public String[] drops= {"HpDrop", "SpeedDrop", "FireRateDrop"};
    void Start()
    {
        dropStrat = new HpStrategy(); // Default
        animator = GetComponent<Animator>();  // Get the Animator component
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find player by tag

        ChangeState(new IdleState(this)); // Start in Idle state
        pool = Pool.singleton;  // Initialize the pool

    }

    void Update()
    {
        if (isDead) return; // Stop updates if dead

        currentState.Update(); 


    }
    public void ChangeState(EnemyStateMachine newState)
    {
        if (isDead || (currentState != null && newState.GetType() == currentState.GetType())) return; // Avoid redundant transitions

        if (currentState != null) currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }


    public void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, 2f * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return; // Prevent taking damage after death

        if (other.CompareTag("Bullet"))  
        {
            Destroy(other.gameObject);
            TakeDamage(5); // Reduce health
            
        }
    }

    private void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;

        if(enemyHP <= 0)
        {
            DropPowerUp();  // Drop a power-up before dying

            print("The Enemy is Dead");
            ChangeState(new DeadState(this));


        }
        else
        {
            print("The Enemy was hit");

        }
    }


    void DropPowerUp()
    {
        int x = Random.Range(0, drops.Length);
        string aDrop = drops[x];
        IDropStrategy strategy = DropStrategyFactory.GetStrategy(aDrop); 
        GameObject powerUpPrefab = GetPowerUpPrefab(strategy);  

        if (Random.value <= dropChance) // Chance to drop the power-up
        {
            Debug.Log("Power-up will drop: " + aDrop);

            // Instantiate the power-up at the enemy's position
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            Debug.Log(aDrop +" Power-up spawned at position: " + transform.position);

        }
        else
        {
            Debug.Log("Power-up did not drop");
        }

    }

    GameObject GetPowerUpPrefab(IDropStrategy strategy)
    {
        if (strategy is HpStrategy)
        {
           
            return powerUpPrefabs[0];  
        }
        else if (strategy is SpeedStrategy)
        {
            // Return the Speed power-up prefab
            return powerUpPrefabs[1]; 
        }
        else if (strategy is FireRateStrategy)
        {
            // Return the Fire Rate power-up prefab
            return powerUpPrefabs[2]; 
        }
        else
        {
            return null;  // Default case if no match
        }
    }


    public void ResetEnemy()
    {
        gameObject.SetActive(true); //  Make sure it's active first!

        isDead = false;
        enemyHP = 15; // Reset health

        animator.Rebind(); //  Safe to reset now that it's active!
        animator.Play("Idle"); // Reset to Idle animation

        GetComponent<Collider2D>().enabled = true; // Re-enable collision
        GetComponent<Rigidbody2D>().simulated = true; // Re-enable physics

        ChangeState(new IdleState(this)); // Reset to idle state
    }




    public IEnumerator RemoveZombie()
    {
        yield return new WaitForSeconds(3f); // Wait 3 seconds
        pool.ReturnObject(gameObject); // Return to the object pool instead of destroying
    }
}
