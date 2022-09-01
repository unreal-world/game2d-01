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
            Items.loadCurrentItems = true;
            sceneFader.FadeTo(levelToLoad);          
        }
    }
}
