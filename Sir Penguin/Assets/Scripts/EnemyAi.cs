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

    private Transform player1;
    private Transform player2;
    private Transform currentTarget;

    private NavMeshAgent agent;
    private Animator animator;

    [Header("Ranges")]
    public float detectionRange = 10f;
    public float attackRange = 2f;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    private int patrolIndex;

    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        FindPlayers();
        GoToNextPatrolPoint();
    }

    void Update()
    {
        if (player1 == null || player2 == null)
        {
            FindPlayers();
        }

        currentTarget = GetClosestPlayer();

        if (currentTarget == null) return;

        float distance = Vector3.Distance(transform.position, currentTarget.position);

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

                agent.SetDestination(currentTarget.position);
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

    void FindPlayers()
    {
        GameObject p1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject p2 = GameObject.FindGameObjectWithTag("Player2");

        if (p1 != null) player1 = p1.transform;
        if (p2 != null) player2 = p2.transform;
    }

    Transform GetClosestPlayer()
    {
        Transform closest = null;
        float minDistance = Mathf.Infinity;

        if (player1 != null)
        {
            float dist1 = Vector3.Distance(transform.position, player1.position);
            if (dist1 < minDistance)
            {
                minDistance = dist1;
                closest = player1;
            }
        }

        if (player2 != null)
        {
            float dist2 = Vector3.Distance(transform.position, player2.position);
            if (dist2 < minDistance)
            {
                minDistance = dist2;
                closest = player2;
            }
        }

        return closest;
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.SetDestination(patrolPoints[patrolIndex].position);
        patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
    }
}
