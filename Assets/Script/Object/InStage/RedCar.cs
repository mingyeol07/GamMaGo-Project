using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCar : TouchObject
{
    [SerializeField] private ItemData itemData;

    public override void ItemUsing(InventoryItem code)
    {
        throw new System.NotImplementedException();
    }

    protected override void TouchEvent()
    {
        GameManager.ins.GetItems(itemData);
    }
}
