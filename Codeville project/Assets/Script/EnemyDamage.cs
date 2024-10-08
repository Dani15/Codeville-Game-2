using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int health = 1; // Enemy's health, set to 3 for example
    public GameObject explosionPrefab;
    public CameraShake cameraShake;

    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with the enemy is a player's bullet
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage(1); // Reduce health by 1 for each bullet hit

            // Destroy the bullet after it hits the enemy
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage; // Subtract the damage from the enemy's health

        // Check if health is zero of below
        if (health <= 0)
        {
            Die(); // Call the function if health is zero
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Die(); //Player dies instantly on contact with the enemy
        }
    }

    void Die()
    {
        Explode();
        Destroy(gameObject);
        if (cameraShake != null) {
            cameraShake.Shake();
        }
    }

    void Explode()
    {
        // Instantiate the explosion effect at the enemy's position and rotation
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }

}
