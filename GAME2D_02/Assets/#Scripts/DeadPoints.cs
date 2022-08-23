using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoints : MonoBehaviour
{
    public GameObject player;
    public Collider2D playerCol;
    bool isDead = true;

    private void Update()
    {
        // Get all components Collider in Object
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        //Browse array 
        foreach (Collider2D collider in colliders)
        {
            if (collider.IsTouching(playerCol) && isDead)
            {
                isDead = false;
                player.GetComponent<PlayerCombat>().TakeDamage(10000);      //Kills player
            }
                
        }
    }

}
