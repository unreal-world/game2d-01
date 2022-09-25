using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerPoint : MonoBehaviour
{
    public Animator bossAnimator;

    public static bool isBossTrigger = false;

    private void Awake()
    {
        isBossTrigger = false;
    }

    // Trigger Boss 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isBossTrigger = true;
            this.gameObject.SetActive(false);
        }
    }
}
