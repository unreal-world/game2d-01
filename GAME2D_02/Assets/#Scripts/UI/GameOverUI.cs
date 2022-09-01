using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverUI;
    SceneFader sceneFader;

    string loadLevelDefault = "Level01";
    string loadMainMenu = "MainMenu";

    private void Awake()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    public void SetGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void PlayAgain()
    {
        sceneFader.FadeTo(loadLevelDefault);
    }

    public virtual void Menu()
    {
        Debug.Log("go to menu !!!!");
        sceneFader.FadeTo(loadMainMenu);
        Time.timeScale = 1f;
    }

}
