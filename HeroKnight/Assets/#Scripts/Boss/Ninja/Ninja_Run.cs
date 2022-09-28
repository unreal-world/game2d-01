using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_Run : StateMachineBehaviour
{
    public float speed = 4f;
    public static float attackRange = 4f;

    Transform player;
    Rigidbody2D rb;
    Boss boss;

    static bool isAttack = true;

    private void Awake()
    {
        isAttack = true;
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            if (isAttack)
            {
                animator.SetTrigger("Attack");
                isAttack = false;
            }
            else
            {
                animator.SetTrigger("RedAttack");
                isAttack = true;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isAttack)
            animator.ResetTrigger("RedAttack");
        else
            animator.ResetTrigger("Attack");

        animator.SetBool("Run", false);
    }
}