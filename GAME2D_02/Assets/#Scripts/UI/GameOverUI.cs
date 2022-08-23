using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverUI;
    SceneFader sceneFader;

    private void Awake()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    public void SetGameOverUI()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayAgain()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public virtual void Menu()
    {
        Debug.Log("go to menu !!!!");
    }

}
