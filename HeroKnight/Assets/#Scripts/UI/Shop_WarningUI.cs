
using UnityEngine;

public class Shop_WarningUI : MonoBehaviour
{
    public GameObject shopUI;

    // use at button YES of panWarning
    public void Yes()
    {
        shopUI.SetActive(false);

        //enabled player moving
        FindObjectOfType<HeroKnight>().enabled = true;
        PlayerCombat.Instance.GetComponent<Rigidbody2D>().simulated = true;
    }

    // use at button NO of panWarning
    public void No()
    {
        this.gameObject.SetActive(false);
    }
}
