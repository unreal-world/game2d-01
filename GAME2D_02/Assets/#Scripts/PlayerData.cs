using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int hearthAmount;
    public int hpAmount;
    public int coinAmount;

    public PlayerData(Items item)
    {
        hearthAmount = item.heartAmount;
        hpAmount = item.hpAmount;
        coinAmount = item.coinAmount;
    }

}
