using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaHealth : MonoBehaviour
{
    public Animator ninjaAnimator;
    public NinjaHealthBarUI ninjaHealthBarUI;
    public GameObject ninjaBossUI;
    public GameObject goToCreditPrefab;
    public GameObject wonUI;
    public GameObject loadNextScene;

    public int maxHealth = 500;
    public float timer = 1f;    //The time boss is not damaged
    public int currentHealth;
    bool isVulnerable = true;   //if true mean that boss can be attacked
    float initTimer;

    private void Awake()
    {
        initTimer = timer;      //save timer
        isVulnerable = true;
        currentHealth = maxHealth;
        ninjaAnimator = GetComponent<Animator>();

        ninjaHealthBarUI.SetMaxHealth(maxHealth);
        ninjaHealthBarUI.SetHealth(currentHealth);
    }

    private void Update()
    {
        if (isVulnerable == false)
            LimitDamage();

        if (BossTriggerPoint.isBossTrigger)
            ninjaBossUI.SetActive(true);
    }

    void LimitDamage()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            isVulnerable = true;
            timer = initTimer;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isVulnerable == false)
            return;     //can not be attacked

        currentHealth -= damage;

        ninjaHealthBarUI.SetHealth(currentHealth);

        isVulnerable = false;

        ninjaAnimator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            ninjaAnimator.SetTrigger("Die");           
            Invoke("Die", 1.3f);
        }
    }

    void Die()
    {
        this.gameObject.SetActive(false);
        ninjaBossUI.SetActive(false);
        Invoke("EnableWonUI", 0.5f);
        Invoke("EnableGoToCredit", 2f);
    }

    void EnableGoToCredit()
    {
        Instantiate(goToCreditPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);

        loadNextScene.SetActive(true);
        loadNextScene.transform.position = this.gameObject.transform.position;  //set position of loadNextScene
    }

    void EnableWonUI()
    {
        wonUI.SetActive(true);
    }
}