using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakLigth : TouchObject
{
    [SerializeField] TextList _notWorkText;

    public override void ItemUsing(InventoryItem code)
    {
        return;
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_notWorkText);
    }
}
