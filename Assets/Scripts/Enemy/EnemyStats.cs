using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType { Small, Medium, Large }
    public EnemyType enemyType;

    public int health;       // Health of the enemy
    public int damage;       // Damage the enemy deals to the player
    public float speed;      // Movement speed of the enemy
    public bool isDead;      // Flag to check if the enemy is dead

    void Start()
    {
        SetStatsBasedOnType();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

    }

    private void SetStatsBasedOnType()
    {
        switch (enemyType)
        {
            case EnemyType.Small:
                health = 50;
                damage = 10;
                speed = 2f;
                break;
            case EnemyType.Medium:
                health = 100;
                damage = 20;
                speed = 1.5f;
                break;
            case EnemyType.Large:
                health = 150;
                damage = 30;
                speed = 1f;
                break;
        }
    }

    // Handle collision trigger with the player to take damagee.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Damage the player
            PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }

    // When enemy dies
    public void Die()
    {
        isDead = true;
        Destroy(gameObject); // Destroy the enemy object
    }

    // When enemy take damage
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die(); // If health is 0 or less, the enemy dies
        }
    }
}
