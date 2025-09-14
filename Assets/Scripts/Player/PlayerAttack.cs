using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float damageAfterTime;
    [SerializeField] private float normalAttackDamage;
    [SerializeField] private PlayerAttackArea playerAttackArea;
    
    private bool _isAttacking;
    
    private static readonly int Attack = Animator.StringToHash("NormalAttack");
    
    public void OnAttack(InputValue value)
    {
        if (_isAttacking) return;
        
        animator.SetTrigger(Attack);
        StartCoroutine(Hit());
    }

    private IEnumerator Hit()
    {
        _isAttacking = true;
        
        yield return new WaitForSeconds(damageAfterTime);
        
        foreach (var attackAreaDamageables in playerAttackArea.Damageables.ToList())
        {
            attackAreaDamageables.Damage(normalAttackDamage);
            playerAttackArea.Damageables.Remove(attackAreaDamageables);
        }
        
        yield return new WaitForSeconds(damageAfterTime);
        _isAttacking = false;
    }
}
