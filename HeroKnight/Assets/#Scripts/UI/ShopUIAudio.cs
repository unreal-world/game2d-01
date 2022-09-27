
using UnityEngine;

public class ShopUIAudio : MonoBehaviour
{
    public AudioSource sourceAudio;
    public AudioClip open, buyItem;

    private void Start()
    {
        Invoke("OpenAudio", 0.5f);
    }

    public void OpenAudio()
    {
        sourceAudio.clip = open;
        sourceAudio.Play();
    }

    public void BuyItemAudio()
    {
        sourceAudio.clip = buyItem;
        sourceAudio.Play();
    }
}
