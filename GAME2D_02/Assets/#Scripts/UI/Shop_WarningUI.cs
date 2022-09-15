
using UnityEngine;

public class Shop_WarningUI : MonoBehaviour
{
    public GameObject shopUI;

    // use at button YES of panWarning
    public void Yes()
    {
        shopUI.SetActive(false);
    }

    // use at button NO of panWarning
    public void No()
    {
        this.gameObject.SetActive(false);
    }
}
