using UnityEngine.UI;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    public Text txtHP;
    public Text txtATK;

    private void Update()
    {
        txtHP.text = PlayerCombat.Instance.maxHealth.ToString();
        txtATK.text = PlayerCombat.Instance.attackDamage.ToString();
    }
}
