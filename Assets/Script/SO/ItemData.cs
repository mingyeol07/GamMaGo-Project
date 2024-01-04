using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item",menuName = "Data/itemData",order = 1)]
public class ItemData : ScriptableObject
{
    public Item itemCode;
    public string Name;
    public string Version;
    public Sprite img;

#if UNITY_EDITOR
    public void Awake()
    {
        Debug.Log($"{name}:{itemCode}");
    }
#endif
}
public enum Item
{
    Driver,
    Tarsh,
    SmartPon
}
