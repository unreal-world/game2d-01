using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaHealth : MonoBehaviour
{
    public Animator ninjaAnimator;
    public GameObject bossTransition;

    public int maxHealth = 500;
    int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        ninjaAnimator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        ninjaAnimator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            ninjaAnimator.SetTrigger("Die");
            bossTransition.SetActive(true);
            Invoke("Die", 1.5f);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}