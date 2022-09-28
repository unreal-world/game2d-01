using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaCombat : MonoBehaviour
{
    public int attackDamage = 10;
    public int redAttackDamage = 15;
    public int strikeDamage = 12;
    public float attackRange = 1f;

    public Transform attackPoint;
    public LayerMask playerLayer;

    //Use in animation Attack
    public void Attack()
    {
        // Detect player in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitEnemies)
        {
            if (player.CompareTag("Player"))
                player.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
            else
                return;
            //if (player.CompareTag("Block"))
            //    return;
            //player.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
        }   
    }

    //Use in animation RedAttack
    public void RedAttack()
    {
        // Detect player in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitEnemies)
        {
            if (player.CompareTag("Player"))
                player.GetComponent<PlayerCombat>().TakeDamage(redAttackDamage);
            else
                return;
            //if (player.CompareTag("Block"))
            //    return;
            //player.GetComponent<PlayerCombat>().TakeDamage(redAttackDamage);
        }
    }

    //Use in animation Strike
    public void Strike()
    {
        // Detect player in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitEnemies)
        {
            if (player.CompareTag("Player"))
                player.GetComponent<PlayerCombat>().TakeDamage(strikeDamage);
            else
                return;
            //if (player.CompareTag("Block"))
            //    return;
            //player.GetComponent<PlayerCombat>().TakeDamage(strikeDamage);

        }
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}