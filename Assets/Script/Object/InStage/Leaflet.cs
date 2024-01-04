using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaflet : TouchObject
{
    [SerializeField]
    TextList _idleText;
    public override void ItemUsing(InventoryItem code)
    {
        return;
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_idleText);
    }
}
