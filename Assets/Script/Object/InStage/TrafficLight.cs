using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : TouchObject
{
    [SerializeField] TextList _idleText;
    protected override void Start()
    {
        base.Start();
    }
    public override void ItemUsing(InventoryItem code)
    {
        MouseExitEvent();
        if ((code.item.itemCode) == Item.Driver)
        {
            code.DeleteItem();
            Eventbus.EventInvoke("Light break");
        }
    }

    protected override void TouchEvent()
    {
            //print("??");
         UIManger.ins.ShowText(_idleText);
    }
}
