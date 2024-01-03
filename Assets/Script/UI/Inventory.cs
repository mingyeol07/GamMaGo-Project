using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _content;
    [SerializeField] GameObject _contentItem;
    [SerializeField] List<int> _items = new List<int>();
    public void GetItem(ItemData data)
    {
        if (!_items.Contains(data.itemCode))
        {
            GameObject obj = Instantiate(_contentItem);
            obj.transform.SetParent(_content.transform);

            GameObject item = obj.transform.GetChild(0).gameObject;
            InventoryItem itemComponent = item.GetComponentInChildren<InventoryItem>();
            itemComponent.useEvent += () => _items.Remove(data.itemCode);
            itemComponent.SetData(data.itemCode,data.img);
            //item.GetComponentInChildren<UnityEngine.UI.Image>().sprite = data.img;
            //itemComponent.item = data.itemCode;

            _items.Add(data.itemCode);
            UIManger.ins.Alert(data.Name, data.Version,data.img);
        }
    }
    public bool IsHaveItem(int code)
    {
        return _items.Contains(code);
    }
}
