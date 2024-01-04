using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : TouchObject
{
    [SerializeField] TextList _touchText;
    protected override void Start()
    {
        base.Start();
        Eventbus.GetEvent(3,() => gameObject.SetActive(false));
    }
    public override void ItemUsing(InventoryItem code)
    {
        if (code.item.itemCode == Item.SmartPon)
        {
            code.DeleteItem();
            Eventbus.EventInvoke(3);
        }
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_touchText);
    }
}
