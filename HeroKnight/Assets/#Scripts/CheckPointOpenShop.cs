
using UnityEngine;

public class CheckPointOpenShop : MonoBehaviour
{
    public GameObject shopUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerPrefs.GetInt("ShopIsOpened") != 1)
        {
            PlayerPrefs.SetInt("ShopIsOpened", 1);  //1: the shop is opened, 0: the shop is not opened.
            
            shopUI.SetActive(true);

            //disabled player moving
            FindObjectOfType<HeroKnight>().enabled = false;
            PlayerCombat.Instance.GetComponent<Rigidbody2D>().simulated = false;

            this.gameObject.SetActive(false);
        }
    }
}
