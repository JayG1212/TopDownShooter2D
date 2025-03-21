// Written By Jay Gunderson
// 03/20/2025
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemiesToSpawn = 5; // Number of enemies to spawn
    public List<Transform> spawnPoints; // Assign spawn locations in the Inspector

    void Start()
    {
        StartCoroutine(SpawnEnemiesOneAtATime());

    }

    void SpawnEnemies()
    {
       for (int i = 0; i < enemiesToSpawn; i++)
    {
        GameObject enemy = Pool.singleton.GetObject(); // Get an enemy from the pool
        if (enemy != null)
        {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)]; // Pick a random spawn point
                enemy.transform.position = spawnPoint.position; // Move enemy to spawn point

                enemy.GetComponent<Enemy>().ResetEnemy(); // Reset zombie stats
            enemy.SetActive(true); // Ensure it's active
        }
    }

    }

    IEnumerator SpawnEnemiesOneAtATime()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = Pool.singleton.GetObject(); // Get an enemy from the pool
            if (enemy != null)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)]; // Pick a random spawn point
                enemy.transform.position = spawnPoint.position; // Move enemy to spawn point

                enemy.GetComponent<Enemy>().ResetEnemy(); // Reset zombie stats
                enemy.SetActive(true); // Ensure the enemy is active
            }

            // Wait for the delay before spawning the next enemy
            yield return new WaitForSeconds(1f);
        }

        // After spawning one-by-one, you can call the regular SpawnEnemies method (if needed)
        SpawnEnemies();
    }


}
