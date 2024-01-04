using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaflet : TouchObject
{
    [SerializeField]
    TextList _idleText;
    [SerializeField]
    ItemData _magazine;

    
    protected override void Start()
    {
        base.Start();
        Eventbus.GetEvent("Get Magazine",() => GameManager.ins.GetItems(_magazine));
    }
    public override void ItemUsing(InventoryItem code)
    {
        return;
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_idleText);
    }
}
