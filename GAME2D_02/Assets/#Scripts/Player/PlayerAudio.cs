using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource sourceAudio;
    public AudioClip dead, hurt, run, attack, block, jump;

    public void DeadAudio()
    {
        sourceAudio.clip = dead;
        sourceAudio.Play();
    }

    public void HurtAudio()
    {
        sourceAudio.clip = hurt;
        sourceAudio.Play();
    }

    public void RunAudio()
    {
        sourceAudio.clip = run;
        sourceAudio.Play();
    }

    public void AttackAudio()
    {
        sourceAudio.clip = attack;
        sourceAudio.Play();
    }

    public void BlockAudio()
    {
        sourceAudio.clip = block;
        sourceAudio.Play();
    }

    public void JumpAudio()
    {
        sourceAudio.clip = jump;
        sourceAudio.Play();
    }

}
