using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDisplay : MonoBehaviour
{
    public ChestSO chest;
    public static bool isOpen = false;    //use to display status of chest

    // Start is called before the first frame update
    void Start()
    {
        if (isOpen == false)
            LoadChest(chest);
        else
            GetComponent<SpriteRenderer>().enabled = true;
    }

    void LoadChest(ChestSO chest)
    {
        foreach (Transform child in this.transform) 
        {
            if (Application.isEditor)
                DestroyImmediate(child.gameObject);
            else
                Destroy(child.gameObject);
        }

        GameObject visuals = Instantiate(chest.chestPrefab);
        visuals.transform.SetParent(this.transform);
        visuals.transform.localPosition = Vector3.zero;
        visuals.transform.rotation = Quaternion.identity;
    }

}
