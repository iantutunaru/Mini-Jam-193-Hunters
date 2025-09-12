using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Player Stats, can add additional stats
    public float maxHealth = 100f;
    public float currentHealth;
    public float maxStamina = 100f;
    public float currentStamina;
    public float moveSpeed = 5f;
    public float staminaDrainRate = 5f;
    public float staminaRegenRate = 2f;

    // Other possible stats, Can be commented out 
    public float attackPower = 10f;
    public float defensePower = 5f;


    private void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    private void Update()
    {
        // Stamina will be drained when the player is moving
        if (currentStamina > 0 && (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D)))
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
        }
        else if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
        }

        // Health & Stamina Limit
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }

    // TakeDamage Function
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
    }

    // Maybe use stamina for jump or sprint. reduce the amount from stamina
    public void UseStamina(float amount)
    {
        currentStamina -= amount;
    }

    // Maybe drinking water or eating something will regenerate staminas.
    public void RegenerateStamina(float amount)
    {
        currentStamina += amount;
    }

    // Just Debug Log for now.
    private void Die()
    {
        // trigger death animation, disable movement, etc.
        Debug.Log("Player has died!");
    }
}
