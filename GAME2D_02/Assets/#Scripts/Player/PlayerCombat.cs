using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public Transform blockPoint;
    public LayerMask enemyLayers;
    public Animator playerAnimator;
    public HealthBar healthBar;
    public Items items;

    public float attackRange = 0.5f;
    public int maxHealth = 100;
    public int attackDamage = 30;
    public int currentHealth;

    public static PlayerCombat Instance;

    private void Awake()
    {
        Instance = this;        //Singleton

        attackPoint = GetComponentInChildren<Transform>().Find("attackPoint");

        if(PlayerPrefs.GetInt("currentHP") != 0 || PlayerPrefs.GetInt("maxHP") != 0 || PlayerPrefs.GetInt("ATK") != 0)
        {
            SetPlayerStats();

            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            currentHealth = maxHealth;

            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
        }

        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            items.UseItemRestoreHP();
            healthBar.SetHealth(currentHealth);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            this.Attack();
        }

        // Rotate attackRange and blockRange -------
        if (GetComponent<SpriteRenderer>().flipX)
        {
            attackPoint.localPosition = new Vector3(-1f, 0.8f, 0f);
            blockPoint.localPosition = new Vector3(-0.15f, 1f, 0f);
        }
        else
        {
            attackPoint.localPosition = new Vector3(1f, 0.8f, 0f);
            blockPoint.localPosition = new Vector3(0.3f, 1f, 0f);
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

            Items.loadCurrentItems = true;

            SavePlayerStats();

            Invoke("RePlay", 1f);
        }
        else if(currentHealth <= 0 && items.heartAmount <= 1)
        {
            this.Death();

            Items.loadCurrentItems = false;  

            Invoke("GameOver", 1f);
        }
    }

    void SetPlayerStats()
    {
        //Set all stats of player when start current scene
        maxHealth = PlayerPrefs.GetInt("maxHP");
        attackDamage = PlayerPrefs.GetInt("ATK");
        currentHealth = PlayerPrefs.GetInt("currentHP");
    }

    void SavePlayerStats()
    {
        PlayerPrefs.SetInt("maxHP", maxHealth);
        PlayerPrefs.SetInt("currentHP", maxHealth);//mean that player has full HP when replay the scene
        PlayerPrefs.SetInt("ATK", attackDamage);
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

        GetComponent<HeroKnight>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;

        CheckPointOpenShop.isOpenShop = false;  //not allow open shop

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
