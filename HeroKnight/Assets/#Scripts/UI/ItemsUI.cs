using UnityEngine.UI;
using UnityEngine;

public class ItemsUI : MonoBehaviour
{
    public Items items;

    public Text txtHeartAmount;
    public Text txtHPAmount;
    public Text txtCoinAmount;

    private void Update()
    {
        txtHeartAmount.text = items.heartAmount.ToString();
        txtHPAmount.text = items.hpAmount.ToString();
        txtCoinAmount.text = items.coinAmount.ToString();
    }
}
