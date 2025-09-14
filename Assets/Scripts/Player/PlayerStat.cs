using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public Image healthBar;

    // Other possible stats, Can be commented out 
    public float attackPower = 10f;
    public float defensePower = 5f;
    
    public GameplayManager gameplayManager;
    
    [SerializeField] private Animator animator;
    [SerializeField] private float invulnerabilityTimer = 1f;
    [SerializeField] private Button doubleOrNothingButton;
    
    private float _timeSinceLastDamage = 0f;
    private bool _allowDamage = true;
    
    private static readonly int Death = Animator.StringToHash("Death");

    private void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    private void FixedUpdate()
    {
        CheckIfDamageIsAllowed();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
            
            if (gameplayManager != null)
            {
                gameplayManager.GameOver();
            }
        }

        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }

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
        if (_allowDamage)
        {
            currentHealth -= damage;
            _allowDamage = false;
        }
    }

    private void CheckIfDamageIsAllowed()
    {
        if (_timeSinceLastDamage < invulnerabilityTimer)
        {
            _timeSinceLastDamage += Time.fixedDeltaTime;
        }
        else
        {
            _allowDamage = true;
            _timeSinceLastDamage = 0f;
        }
    }

    public void Heal(float amount)
    {
        if (amount + currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
    }

    // Maybe use stamina for jump or sprint. reduce the amount from stamina
    public void UseStamina(float amount)
    {
        currentStamina -= amount;
    }

    // Maybe drinking water or eating something will regenerate stamina
    public void RegenerateStamina(float amount)
    {
        currentStamina += amount;
    }

    // Just Debug Log for now.
    private void Die()
    {
        animator.SetTrigger(Death);
    }

    public void DoubleOrNothing()
    {
        var random = Random.Range(0, 2);

        if (random == 0)
        {
            maxHealth = 200f;
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = 1;
        }
        
        doubleOrNothingButton.interactable = false;
    }
}
