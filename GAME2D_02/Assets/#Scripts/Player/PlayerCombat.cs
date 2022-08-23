using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public Animator playerAnimator;
    public HealthBar healthBar;
    public Items items;

    public float attackRange = 0.5f;
    public int maxHealth = 100;
    public int attackDamage = 15;
    int currentHealth;

    public static PlayerCombat Instance;

    private void Awake()
    {
        Instance = this;        //Singleton

        attackPoint = GetComponentInChildren<Transform>().Find("attackPoint");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            this.Attack();
        }

        // Rotate attackRange -------
        if (GetComponent<SpriteRenderer>().flipX)
        {
            attackPoint.localPosition = new Vector3(-1f, 0.8f, 0f);
        }
        else
        {
            attackPoint.localPosition = new Vector3(1f, 0.8f, 0f);
        }
        // ---------------------------
            
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        playerAnimator.SetTrigger("Hurt");

        if (currentHealth <= 0 && items.heartAmount > 1)
        {
            this.Death();
            Invoke("RePlay", 1f);
        }
        else if(currentHealth <= 0 && items.heartAmount <= 1)
        {
            this.Death();
            Invoke("GameOver", 1f);
        }
    }

    void GameOver()
    {
        GameManager.GameOver();
    }

    void RePlay()
    {
        GameManager.RePlay();
    }

    public void Death()
    {
        items.heartAmount--;

        items.SaveItems();  // save current items

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        playerAnimator.SetTrigger("Death");
    }

    void Attack()
    {
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponentInParent<EnemyCombat>().TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}