using UnityEngine.SceneManagement;
using UnityEngine;

public class DiedUI : MonoBehaviour
{
    public GameObject diedUI;
    SceneFader sceneFader;

    private void Awake()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    public void SetDiedUI()
    {
        diedUI.SetActive(true);
        Invoke("ReLoad", 1f);      
    }

    public void ReLoad()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

}
