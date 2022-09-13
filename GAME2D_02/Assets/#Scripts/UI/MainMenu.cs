using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    string levelToLoad = "Level01";

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);

        PlayerPrefs.DeleteAll();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
