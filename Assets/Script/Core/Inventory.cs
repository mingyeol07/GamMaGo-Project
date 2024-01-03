using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Inventory : MonoBehaviour
{
    public enum Stage
    {
        Stage1, Stage2, Stage3
    }

    [SerializeField] private GameObject _content;
    [SerializeField] private GameObject _contentItem;
    [SerializeField] private List<int> _items = new List<int>();

    private bool _inventoryOpen;
    public bool GetItem(ItemData data)
    {
        if (!_items.Contains(data.itemCode))
        {
            GameObject obj = Instantiate(_contentItem);
            obj.transform.SetParent(_content.transform);

            InventoryItem itemComponent = obj.GetComponentInChildren<InventoryItem>();
            //itemComponent.useEvent += () => _items.Remove(data.itemCode);
            itemComponent.SetData(data,data.img);
            //item.GetComponentInChildren<UnityEngine.UI.Image>().sprite = data.img;
            //itemComponent.item = data.itemCode;

            _items.Add(data.itemCode);
            //UIManger.ins.Alert(data.Name, data.Version,data.img);
            return true;
        }
        return false;
    }
    public bool IsHaveItem(int code)
    {
        return _items.Contains(code);
    }
    public void OnOffInventory()
    {
        Sequence mySequence = DOTween.Sequence();
        DOTween.Rewind(transform); transform.localPosition = new Vector3(!_inventoryOpen ? 810 : 1110,0);
        mySequence.Append(transform.DOLocalMoveX(_inventoryOpen ? 810 : 1110, .5f).SetEase(Ease.OutQuad));
        //equence mySequence = DOTween.Sequence();
        _inventoryOpen = !_inventoryOpen;
    }
}
