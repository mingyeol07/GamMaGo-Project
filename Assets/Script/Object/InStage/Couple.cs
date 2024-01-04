using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couple : TouchObject
{
    public override void ItemUsing(InventoryItem code)
    {
        return;
    }

    protected override void TouchEvent()
    {
        throw new System.NotImplementedException();
    }
}
