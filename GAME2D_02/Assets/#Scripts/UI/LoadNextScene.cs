using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    public SceneFader sceneFader;
    public Items items;
    public string levelToLoad = "Level02";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Save items in current scene and load it in next scene
            items.SaveItems();

            //Save all stats of player when load next scene
            PlayerPrefs.SetInt("currentHP", PlayerCombat.Instance.currentHealth);
            PlayerPrefs.SetInt("maxHP", PlayerCombat.Instance.maxHealth);
            PlayerPrefs.SetInt("ATK", PlayerCombat.Instance.attackDamage);

            Items.loadCurrentItems = true;

            sceneFader.FadeTo(levelToLoad);          
        }
    }
}
