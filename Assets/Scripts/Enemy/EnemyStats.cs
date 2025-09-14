using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour, IDamageable
{
    public enum EnemyType { Small, Medium, Large }
    public EnemyType enemyType;

    public float health;       // Health of the enemy
    public int damage;       // Damage the enemy deals to the player
    public float speed;      // Movement speed of the enemy
    public bool isDead;      // Flag to check if the enemy is dead
    
    [SerializeField] private Animator animator;
    [SerializeField] private DamageFlash damageFlash;

    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Death = Animator.StringToHash("Death");  
    
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
                health = 20;
                damage = 5;
                speed = 2f;
                break;
            case EnemyType.Medium:
                health = 40;
                damage = 10;
                speed = 1.5f;
                break;
            case EnemyType.Large:
                health = 60;
                damage = 20;
                speed = 1f;
                break;
        }
    }

    // Handle collision trigger with the player to take damagee.
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        // Damage the player
        var player = other.gameObject.GetComponent<PlayerStats>();
            
        if (player == null) return;
            
        animator.SetTrigger(Attack);
        player.TakeDamage(damage);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        // Damage the player
        var player = other.gameObject.GetComponent<PlayerStats>();

        if (player == null) return;
            
        animator.SetTrigger(Attack);
        player.TakeDamage(damage);
    }

    // When enemy dies
    public void Die()
    {
        isDead = true;
        animator.SetTrigger(Death);
        StopAllCoroutines();
        Destroy(gameObject); // Destroy the enemy object
    }

    // When enemy take damage
    public void Damage(float damageAmount)
    {
        health -= damageAmount;
        damageFlash.CallDamageFlash();
        
        if (health <= 0)
        {
            Die(); // If health is 0 or less, the enemy dies
        }
    }
}
