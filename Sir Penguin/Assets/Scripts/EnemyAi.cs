using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Chase,
        Attack
    }

    public State currentState;

    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    public float detectionRange = 10f;
    public float attackRange = 2f;

    public Transform[] patrolPoints;
    private int patrolIndex;

    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        GoToNextPatrolPoint();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
            currentState = State.Attack;
        else if (distance <= detectionRange)
            currentState = State.Chase;
        else
            currentState = State.Patrol;

        switch (currentState)
        {
            case State.Patrol:
                isAttacking = false;
                animator.ResetTrigger("Attack");

                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GoToNextPatrolPoint();
                break;

            case State.Chase:
                isAttacking = false;
                animator.ResetTrigger("Attack");

                agent.SetDestination(player.position);
                break;

            case State.Attack:
                agent.ResetPath();

                if (!isAttacking)
                {
                    animator.SetTrigger("Attack");
                    isAttacking = true;
                }
                break;
        }

        bool isMoving = agent.velocity.magnitude > 0.1f;
        animator.SetBool("isMoving", isMoving);
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.SetDestination(patrolPoints[patrolIndex].position);
        patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
    }
}
