using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaCombat : MonoBehaviour
{
    public int attackDamage = 20;
    public int redAttackDamage = 30;
    public int strikeDamage = 10;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    //Use in animation Attack
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        // Detect player in range of attack
        Collider2D[] colInfo = Physics2D.OverlapCircleAll(pos, attackRange, attackMask);
        foreach (Collider2D player in colInfo)
        {
            if (player.CompareTag("Block"))
                return;
            player.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
        }   
    }

    //Use in animation RedAttack
    public void RedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        // Detect player in range of attack
        Collider2D[] colInfo = Physics2D.OverlapCircleAll(pos, attackRange, attackMask);
        foreach (Collider2D player in colInfo)
        {
            if (player.CompareTag("Block"))
                return;
            player.GetComponent<PlayerCombat>().TakeDamage(redAttackDamage);
        }
    }

    //Use in animation Strike
    public void Strike()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        // Detect player in range of attack
        Collider2D[] colInfo = Physics2D.OverlapCircleAll(pos, attackRange, attackMask);
        foreach (Collider2D player in colInfo)
        {
            if (player.CompareTag("Block"))
                return;
            player.GetComponent<PlayerCombat>().TakeDamage(strikeDamage);
            
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}