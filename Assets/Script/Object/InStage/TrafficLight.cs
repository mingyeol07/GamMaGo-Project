using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : TouchObject
{
    [SerializeField] TextList _idleText;
    [SerializeField] TextList _notWorkText;
    private bool _isNotWork;
    protected override void Start()
    {
        base.Start();
        _isNotWork = false;
    }
    public override void ItemUsing(InventoryItem code)
    {
        MouseExitEvent();
        if ((code.item.itemCode) == Item.Driver)
        {
            code.DeleteItem();
            _isNotWork = true;
            Eventbus.EventInvoke("Light break");
        }
    }

    protected override void TouchEvent()
    {
        if (!_isNotWork)
            //print("??");
            UIManger.ins.ShowText(_idleText);
        else UIManger.ins.ShowText(_notWorkText);
    }
}
