using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator enemyAnimator;
    public Transform attackPoint;
    public LayerMask playerLayers;

    public int maxHealth = 100;
    int currentHealth;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public bool isInvulneralbe = false;

    private void Awake()
    {
        currentHealth = maxHealth;
        enemyAnimator = GetComponent<Animator>();      
    }

    public void TakeDamage(int damage)
    {
        if (isInvulneralbe)
            return;

        currentHealth -= damage;

        enemyAnimator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            enemyAnimator.SetBool("IsDead", true);
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponentInChildren<Collider2D>().enabled = false;
            Invoke("Die", 1f);
        }
    }

    void Die()
    {
        Debug.Log("Die");
        Destroy(gameObject);
    }


    // Use in event animation "Attack" of Enemy
    public void Attack()
    {
        // Detect player in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Block"))
                return;
            enemy.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
