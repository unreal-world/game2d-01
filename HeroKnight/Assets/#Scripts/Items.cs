using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Items : MonoBehaviour
{

    public int heartAmount = 1;
    [HideInInspector]
    public int hpAmount = 0;
    [HideInInspector]
    public int coinAmount = 0;

    public static bool loadCurrentItems = false; 

    private void Awake()
    {
        LoadItemsOnAwake(); 
    }

    void LoadItemsOnAwake()
    {
        if (!loadCurrentItems)
        {
            LoadItemsDefault();
        }
        else
        {
            LoadCurrentItems();
        }
    }

    public void SaveItems()
    {
        SaveSystem.Save(this);
    }

    public void UseItemRestoreHP()
    {
        if (hpAmount > 0 && PlayerCombat.Instance.currentHealth < PlayerCombat.Instance.maxHealth)
        {
            PlayerCombat.Instance.hpRestore.SetActive(true);
            Invoke("DisableHpRestore", 0.8f);

            PlayerCombat.Instance.currentHealth += 50;
            hpAmount--;
            if (PlayerCombat.Instance.currentHealth > PlayerCombat.Instance.maxHealth)
                PlayerCombat.Instance.currentHealth = PlayerCombat.Instance.maxHealth;
        }
    }

    void DisableHpRestore()
    {
        PlayerCombat.Instance.hpRestore.SetActive(false);
    }

    public void LoadCurrentItems()
    {
        PlayerData data = SaveSystem.Load();

        heartAmount = data.hearthAmount;
        hpAmount = data.hpAmount;
        coinAmount = data.coinAmount;
    }

    public void LoadItemsDefault()
    {
        heartAmount = 2;
        hpAmount = 0;
        coinAmount = 0;
    }
}
