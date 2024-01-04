using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingOwner : TouchObject
{

    [SerializeField]
    TextList _idleText;
    [SerializeField]
    ItemData _paint;


    public override void ItemUsing(InventoryItem code)
    {
        if (code.item.itemCode == Item.Magazine)
        {
            GameManager.ins.GetItems(_paint);
            code.DeleteItem();
        }
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_idleText);
    }
}
