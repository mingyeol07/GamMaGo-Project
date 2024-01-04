using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosswalk : TouchObject
{
    [SerializeField]
    TextList _idleText;
    [SerializeField]
    GameObject Garbege;

    public override void ItemUsing(InventoryItem code)
    {
        if(code.item.itemCode == Item.Garbage)
        {
            code.DeleteItem();
            Garbege.SetActive(true);
        }
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_idleText);
    }
}
