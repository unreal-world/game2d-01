using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    string loadGuideMenu = "GuideMenu";
    string loadMainMenu = "MainMenu";

    public void GuideMenuUI()
    {
        sceneFader.FadeTo(loadGuideMenu);
    }

    public void Back()
    {
        sceneFader.FadeTo(loadMainMenu);
    }
}
