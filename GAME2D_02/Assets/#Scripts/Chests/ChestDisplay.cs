using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDisplay : MonoBehaviour
{
    public ChestSO chest;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(gameObject.name) == 1)       //Chest is opened
            GetComponent<SpriteRenderer>().enabled = true;
        else
            LoadChest(chest);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetChestIsOpened();
        }
    }

    void SetChestIsOpened()
    {
        PlayerPrefs.SetInt(gameObject.name, 1);     //key value = 1: chest is opened
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
