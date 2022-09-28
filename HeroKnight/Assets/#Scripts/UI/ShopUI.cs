
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject panelWarning;
    public Items item;
    public ShopUIAudio audioSource;

    private void Awake()
    {
        audioSource = GetComponent<ShopUIAudio>();
    }

    //Button close in ShopUI
    public void CloseShopUI()
    {
        panelWarning.SetActive(true);
    }

    //Button BuyATK in ShopUI
    public void BuyATK()
    {
        if(item.coinAmount >= 2)
        {
            PlayerCombat.Instance.attackDamage += 5;
            item.coinAmount = item.coinAmount - 2;          
            audioSource.BuyItemAudio();
        }
    }

    //Button BuyHP in ShopUI
    public void BuyHP()
    {
        if(item.coinAmount >= 1)
        {
            item.hpAmount++;
            item.coinAmount--;
            audioSource.BuyItemAudio();
        }
    }

}
