using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    public State currentState;

    public Transform player;
    private CharacterController controller;
    private Animator animator;

    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public float attackRange = 2f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            player = playerObj.transform;
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
            currentState = State.Idle;

        switch (currentState)
        {
            case State.Idle:
                animator.SetBool("isMoving", false);
                break;

            case State.Chase:
                animator.SetBool("isMoving", true);

                Vector3 dir = (player.position - transform.position).normalized;
                dir.y = 0;

                transform.forward = dir;
                controller.Move(dir * moveSpeed * Time.deltaTime);
                break;

            case State.Attack:
                animator.SetBool("isMoving", false);
                animator.SetTrigger("Attack");
                break;
        }
    }
}
