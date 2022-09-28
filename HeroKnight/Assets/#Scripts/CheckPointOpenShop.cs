
using UnityEngine;

public class CheckPointOpenShop : MonoBehaviour
{
    public GameObject shopUI;

    public static bool isOpenShop = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isOpenShop == true)
        {
            shopUI.SetActive(true);

            //disabled player moving
            FindObjectOfType<HeroKnight>().enabled = false;
            PlayerCombat.Instance.GetComponent<Rigidbody2D>().simulated = false;

            this.gameObject.SetActive(false);
        }
    }
}
