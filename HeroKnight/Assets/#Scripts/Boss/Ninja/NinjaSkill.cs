using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSkill : MonoBehaviour
{
    public Transform skillPoint;
    public GameObject blastPrefab;
    public Animator ninjaAnimator;

    public float timer = 5f;
    float initTimer;
    int count = 0; 

    private void Awake()
    {
        ninjaAnimator = GetComponent<Animator>();
        initTimer = timer;
    }

    private void Update()
    {
        if (!BossTriggerPoint.isBossTrigger)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f && ninjaAnimator.GetCurrentAnimatorStateInfo(0).IsName("Ninja_Idle"))
        {
            timer = initTimer;

            ninjaAnimator.SetBool("Skill", true);
            Invoke("Skill", 0.5f);      //hardcode                        
        }

        if (count >= 5)
        {
            ninjaAnimator.SetBool("Skill", false);
            count = 0;
        }
    }

    void Skill()
    {
        Instantiate(blastPrefab, skillPoint.position, skillPoint.rotation);
        count++;
    }
}
