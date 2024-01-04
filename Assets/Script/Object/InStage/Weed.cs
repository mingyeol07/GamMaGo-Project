using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed : TouchObject
{
    [SerializeField]
    TextList _idleText;
    [SerializeField]
    ItemData spray, envelopes;

    private void Start()
    {
        base.Start();
        Eventbus.GetEvent("Get Spray", () => GameManager.ins.GetItems(spray, envelopes));
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
