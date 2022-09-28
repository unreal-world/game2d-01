using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public float speed = 15f;
    public int skillDamage = 13;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerCombat>().TakeDamage(skillDamage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
            Destroy(gameObject);
    }
}
