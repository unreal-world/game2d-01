using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip openAudio;

    public void OpenAudio()
    {
        audioSource.clip = openAudio;
        audioSource.Play();
    }
}
