using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public Animator animator;
    public GameObject reward;
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
            ChestDisplay.isOpen = true;     //Set status of chest when player opened the chest
        }
    }

    // Used in animation event
    public void ActiveReward()
    {
        reward.SetActive(true);
    }

    public void PlusPlayerStats()
    {
        PlayerCombat.Instance.maxHealth += 20;
        PlayerCombat.Instance.healthBar.SetMaxHealth(PlayerCombat.Instance.maxHealth);
        PlayerCombat.Instance.attackDamage += 5;
        reward.SetActive(false);
    }

    public void PlusHeartAmount()
    {
        items.heartAmount++;
        reward.SetActive(false);
    }

    public void PlusHPAmount()
    {
        items.hpAmount++;
        reward.SetActive(false);
    }

    public void PlusCoinAmount()
    {
        items.coinAmount++;
        reward.SetActive(false);
    }
}
