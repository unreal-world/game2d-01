
using UnityEngine;

public class Credit : MonoBehaviour
{
    float timer;

    private void Awake()
    {
        timer = 25f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
            Application.Quit();
    }
}
