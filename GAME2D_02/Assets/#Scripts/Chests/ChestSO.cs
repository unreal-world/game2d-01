using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chest")]
public class ChestSO : ScriptableObject
{
    public GameObject chestPrefab;
    public string chestName;
    public string description;
}
