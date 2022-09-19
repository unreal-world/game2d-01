using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();    //Delete all keys and values from the preferences
    }

    public static void GameOver()
    {
        FindObjectOfType<GameOverUI>().SetGameOverUI();
        FindObjectOfType<PauseMenuUI>().enabled = false;

        PlayerPrefs.DeleteAll();

        Time.timeScale = 0f;
    }

    public static void RePlay()
    {
        FindObjectOfType<HeroKnight>().enabled = false;
        FindObjectOfType<DiedUI>().SetDiedUI();
    }

}
