using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Market : TouchObject
{
    [SerializeField]
    TextList _idleText;
    [SerializeField]
    ItemData _iceCream;

    public override void ItemUsing(InventoryItem code)
    {
        if (code.item.itemCode == Item.Coin)
        {
            GameManager.ins.GetItems(_iceCream);
            code.DeleteItem();
        }
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_idleText);
    }
}
