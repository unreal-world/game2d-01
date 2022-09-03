using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Collider2D col;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            col.enabled = true;
        }
        else if(Input.GetButtonUp("Fire2"))
            col.enabled = false;
    }
}
