using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
[System.Serializable]

public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}
public class Pool : MonoBehaviour
{
    public static Pool singleton;
    public List<PoolItem> items;
    public List<GameObject> pooledItems;
    GameObject anObject;
    void Awake()
    {
        singleton = this;
        pooledItems = new List<GameObject>();


        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject anObject = Instantiate(item.prefab);
                anObject.SetActive(false);
                pooledItems.Add(anObject);
            }

        }
    }
    public GameObject GetObject()
    {
        string aTag = "Enemy";

        foreach (var obj in pooledItems)
        {
            if (!obj.activeInHierarchy && obj.CompareTag(aTag))
            {
                obj.SetActive(true); // Activate the object before returning it
                return obj;
            }
        
        }

        return null; // No available object and not expandable


    }


    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);  // Deactivate the object
        StartCoroutine(DelayedReset(obj));  // Start a coroutine for delayed reset

    }

    private IEnumerator DelayedReset(GameObject obj)
    {
        yield return new WaitForSeconds(2f); // Wait for 1 second
        int randomNum = Random.Range(0,4); // Value
        switch (randomNum)
        {
            case 0:
                // Spawnpoint 1
                obj.transform.position = new Vector3(0,-2,0);  // Reset the position (optional)
                break;

            case 1:
                // Spawnpoint 2
                obj.transform.position = new Vector3(29, -27, 0);
                break;

            case 2:
                // Spawnpoint 3
                obj.transform.position = new Vector3(0,-49,0);  // Reset the position (optional)
                break;

            case 3:
                // Spawnpoint 4
                obj.transform.position = new Vector3(-27,-27,0);  // Reset the position (optional)
                break;
        }

        obj.transform.rotation = Quaternion.identity; // Reset rotation (optional)

        Enemy enemyScript = obj.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.ResetEnemy();
        }
    }
    public GameObject GetObjectByTag(string tag)
    {
        foreach (var obj in pooledItems)
        {
            if (!obj.activeInHierarchy && obj.CompareTag(tag))
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null; // No inactive object available
    }

}


