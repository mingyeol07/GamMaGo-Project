using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _content;
    [SerializeField] GameObject _contentItem;
    public void ItemListReset()
    {
        foreach (Transform obj in _content.transform) Destroy(obj.gameObject);
    }
    public void AddItem()
    {
        GameObject obj = Instantiate(_contentItem);
        obj.transform.SetParent(_content.transform);
    }
}
