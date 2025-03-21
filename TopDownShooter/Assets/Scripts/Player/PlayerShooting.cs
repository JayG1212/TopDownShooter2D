using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    [SerializeField] private float bulletSpeed;


    private PlayerIPActions inputActions;

    // Methods
    private void Awake()
    {
        inputActions = new PlayerIPActions(); // Initialize input actions
    }


    private void OnEnable()
    {
        inputActions.Enable(); // Enable inputs
        inputActions.Player.Fire.performed += ctx => FireBullet(); // Subscribe to Shoot action
    }

    private void OnDisable()
    {
        inputActions.Player.Fire.performed -= ctx => FireBullet(); // Unsubscribe to avoid memory leaks
        inputActions.Disable();
    }
    public void FireBullet()
    {
        // Instantiate the bullet at the shooting point
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

        // Shoots bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = shootingPoint.up * bulletSpeed;  // This assumes the shooting point faces up or in the direction you want to fire

        // Destroys prefab
        Destroy(bullet, 2f);
    }
    public void AddFireRate(float time)
    {
        if (bulletSpeed < 40)
        {
            bulletSpeed *= 2;
            StartCoroutine(FireRateRest(time));
        }
    }

    private IEnumerator FireRateRest(float time)
    {
        yield return new WaitForSeconds(time);
        bulletSpeed /= 2;
    }
}
