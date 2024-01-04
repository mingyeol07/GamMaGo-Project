using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BlueCar : TouchObject
{
    [SerializeField]
    TextList _idleText;
    [SerializeField]
    Sprite _policeCar;

    public override void ItemUsing(InventoryItem code)
    {
        if(code.item.itemCode == Item.paint)
        {
            Eventbus.EventInvoke("Set PoliceCar");
            _renderer.sprite = _policeCar;
            code.DeleteItem();
        }
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_idleText);
    }
}
