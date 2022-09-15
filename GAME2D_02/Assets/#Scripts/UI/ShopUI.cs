
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject panelWarning;
    public Items item;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CloseShopUI()
    {
        panelWarning.SetActive(true);
    }

    public void BuyATK()
    {
        if(item.coinAmount >= 1)
        {
            PlayerCombat.Instance.attackDamage += 5;
            item.coinAmount--;
            audioSource.Play();
        }
    }

    public void BuyHP()
    {
        if(item.coinAmount >= 2)
        {
            item.hpAmount++;
            item.coinAmount = item.coinAmount - 2;
            audioSource.Play();
        }
    }

}
