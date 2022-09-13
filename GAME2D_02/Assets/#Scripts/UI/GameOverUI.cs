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

        PlayerPrefs.DeleteAll();

        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

    public virtual void Menu()
    {
        sceneFader.FadeTo(loadMainMenu);

        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

}
