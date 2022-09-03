using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public Animator animator;
    public GameObject reward;   //display reward of chest
    public Items items;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        items = FindObjectOfType<Items>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Open");
        }
    }

    // Used in animation event
    public void ActiveReward()
    {
        reward.SetActive(true);
    }

    // Used in animation event
    public void PlusPlayerStats()
    {
        PlayerCombat.Instance.maxHealth += 20;
        PlayerCombat.Instance.healthBar.SetMaxHealth(PlayerCombat.Instance.maxHealth);
        PlayerCombat.Instance.healthBar.SetHealth(PlayerCombat.Instance.currentHealth);
        PlayerCombat.Instance.attackDamage += 10;
        
        //Save maxHP and ATK when open the diamond chest
        PlayerPrefs.SetInt("maxHP", PlayerCombat.Instance.maxHealth);
        PlayerPrefs.SetInt("ATK", PlayerCombat.Instance.attackDamage);

        reward.SetActive(false);
    }

    // Used in animation event
    public void PlusHeartAmount()
    {
        items.heartAmount++;
        reward.SetActive(false);
    }

    // Used in animation event
    public void PlusHPAmount()
    {
        items.hpAmount++;
        reward.SetActive(false);
    }

    // Used in animation event
    public void PlusCoinAmount()
    {
        items.coinAmount++;
        reward.SetActive(false);
    }
}
