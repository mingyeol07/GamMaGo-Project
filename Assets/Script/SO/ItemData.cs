using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item",menuName = "Data/itemData",order = 1)]
public class ItemData : ScriptableObject
{
    public int itemCode;
    public string Name;
    public string Version;
    public Sprite img;
}
