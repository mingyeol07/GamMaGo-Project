using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couple : TouchObject
{
    [SerializeField]
    TextList _idleText;

    [SerializeField]
    Sprite Angry;
    public override void ItemUsing(InventoryItem code)
    {
        if(code.item.itemCode == Item.Coffee)
        {
            _renderer.sprite = Angry;
            code.DeleteItem();
        }
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_idleText);
    }
}
