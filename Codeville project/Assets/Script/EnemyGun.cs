using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootingInterval = 2f;

    private float shootingTimer;

    void Update()
    {
        //Increment the timer
        shootingTimer += Time.deltaTime;

        // Shoot when the timer reaches the interval
        if (shootingTimer >= shootingInterval)
        {
            Shoot();
            shootingTimer = 0f;
        }
    }

    // Update is called once per frame
    void Shoot()
    {
        //Instantiate the bullet at the fire point's position and rotation
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
