using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAudio : MonoBehaviour
{
    public AudioSource sourceAudio;
    public AudioClip strike, run, attack, skill;

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

    public void StrikeAudio()
    {
        sourceAudio.clip = strike;
        sourceAudio.Play();
    }

    public void SkillAudio()
    {
        sourceAudio.clip = skill;
        sourceAudio.Play();
    }

}
