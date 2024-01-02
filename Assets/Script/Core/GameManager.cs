using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    List<int> _items = new List<int>();
    //public int ItemCode = 0;
    bool _nowAlert;
    [SerializeField] private PopupPanel _popup;
    [SerializeField] private Inventory _inventory;

    
    public void ShowAlert(string title, string desc)
    {
        _nowAlert = true;
        //스택으로
        _popup.ShowPopup(title, desc);
    }
    public void GetItem(ItemData data)
    {
        if (!_items.Contains(data.itemCode))
        {
            _inventory.AddItem();
            _items.Add(data.itemCode);
            ShowAlert(data.Name, data.Version);
        }
    }
    public bool IsHaveItem(int code)
    {
        return _items.Contains(code);
    }
    public void HideAlert()
    {
        _nowAlert = false;
        _popup.HidePopup();
    }
    public bool NoneAlert()
    {
        return !_nowAlert && !TextManger.ins.IsTestShow;
    }
}
