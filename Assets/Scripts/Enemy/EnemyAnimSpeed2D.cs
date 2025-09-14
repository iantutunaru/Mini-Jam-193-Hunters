using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class EnemyAnimSpeed2D : MonoBehaviour
{
    public float damp = 0.1f;
    Animator anim;
    NavMeshAgent agent;

    void Awake()
    {
        // Get the Component of the game obj attached to this script
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // SetFloat Speed for transition between Walk & Idle to work
        float speed = agent.velocity.magnitude;
        anim.SetFloat("Speed", speed, damp, Time.deltaTime);
    }
}
