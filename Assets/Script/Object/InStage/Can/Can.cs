using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : TouchObject
{
    [SerializeField]
    TextList _idleText;
    [SerializeField]
    ItemData Coin, Medicine;
    protected override void Start()
    {
        base.Start();
        Eventbus.GetEvent("Get Coin", () => GameManager.ins.GetItems(Coin, Medicine));
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
