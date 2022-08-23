using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hurt, death, walk, attack;

    public void PlayHurtAudio()
    {
        audioSource.clip = hurt;
        audioSource.Play();
    }

    public void PlayDeathdAudio()
    {
        audioSource.clip = death;
        audioSource.Play();
    }

    public void PlayWalkAudio()
    {
        audioSource.clip = walk;
        audioSource.Play();
    }

    public void PlayAttackAudio()
    {
        audioSource.clip = attack;
        audioSource.Play();
    }
}
