using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    private static readonly int Attack = Animator.StringToHash("NormalAttack");
    
    public void OnAttack(InputValue value)
    {
        animator.SetTrigger(Attack);
    }
}
