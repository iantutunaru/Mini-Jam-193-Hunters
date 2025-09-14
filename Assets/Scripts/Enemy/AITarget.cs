using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

[RequireComponent(typeof(NavMeshAgent))]
public class AITarget : MonoBehaviour
{
    public Transform target;
    public float attackDistance;
    
    [SerializeField]
    private NavMeshAgent mAgent;
    [SerializeField]
    private Animator mAnimator;
    
    private float _mDistance;
    
    private static readonly int Attack = Animator.StringToHash(("Attack"));
    
    private void FixedUpdate()
    {
        _mDistance = Vector3.Distance(mAgent.transform.position, target.position);

        if (_mDistance < attackDistance)
        {
            mAgent.isStopped = true;
            //mAnimator.SetBool(Attack, true);
        }
        else
        {
            mAgent.isStopped = false;
            //mAnimator.SetBool(Attack, false);
            mAgent.destination = target.position;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void OnAnimatorMove()
    {
        /*
        if (mAnimator.GetBool(Attack) == false)
        {
            mAgent.speed = (mAnimator.deltaPosition / Time.fixedDeltaTime).magnitude;
        }*/
    }
}
