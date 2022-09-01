using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoints : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCombat.Instance.TakeDamage(1000);
        }
    }

}
