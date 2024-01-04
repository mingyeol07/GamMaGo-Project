using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCar : TouchObject
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private TextList textList;

    public override void ItemUsing(InventoryItem code)
    {
        return;
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(textList);
    }
}
