using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    //[HideInInspector]
    public int heartAmount = 1;
    //[HideInInspector]
    public int hpAmount = 0;
    //[HideInInspector]
    public int coinAmount = 0;

    public void SaveItems()
    {
        SaveSystem.Save(this);
    }

    public void LoadItems()
    {
        PlayerData data = SaveSystem.Load();

        heartAmount = data.hearthAmount;
        hpAmount = data.hpAmount;
        coinAmount = data.coinAmount;
    }
}
