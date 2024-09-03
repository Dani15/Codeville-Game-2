using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    [SerializeField] private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize player health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            GameOver();
        }
    }

    void Die()
    {
        // Add logic for player death, e.g., play death animation, show game over screen
        Debug.Log("Player Died");
        Destroy(gameObject); //Destroy the player GameObject
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check if the collision object is an enemy bullet
        EnemyBullet bullet = collision.gameObject.GetComponent<EnemyBullet>();
        if (bullet != null && bullet.isEnemy)
        {
            TakeDamage(1); //Assume each bullet does 1 damage

            Destroy (bullet.gameObject); // Destroy the bullet
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the player collided with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die(); //Player dies instantly on contact with the enemy
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
    }
}
