using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static void GameOver()
    {
        FindObjectOfType<HeroKnight>().enabled = false;
        FindObjectOfType<GameOverUI>().SetGameOverUI();
        FindObjectOfType<PauseMenuUI>().enabled = false;
        ChestDisplay.isOpen = false;    // Set status of chest when game over
    }

    public static void RePlay()
    {
        FindObjectOfType<HeroKnight>().enabled = false;
        FindObjectOfType<DiedUI>().SetDiedUI();
    }

}
