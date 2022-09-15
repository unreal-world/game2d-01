
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject panelWarning;

    public void CloseShopUI()
    {
        panelWarning.SetActive(true);
    }

}
