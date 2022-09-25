using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_Idle : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(BossTriggerPoint.isBossTrigger)
        {
            if (Vector2.Distance(player.position, rb.position) > Ninja_Run.attackRange)
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetTrigger("Strike");
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Strike");
    }
}
