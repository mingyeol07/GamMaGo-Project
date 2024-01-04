using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : TouchObject
{
    [SerializeField]
    ItemData Driver, Tash;
    [SerializeField]
    TextList _emptyText;
    private bool _isEmpty = false;
    protected override void Start()
    {
        base.Start();
        _isEmpty = false;
    }
    public override void ItemUsing(InventoryItem code)
    {
        return;
    }

    protected override void TouchEvent()
    {
        if (!_isEmpty)
        {
            GameManager.ins.GetItems(Tash);
            SetEffect();
            _isEmpty = true;
        }
        else UIManger.ins.ShowText(_emptyText);
    }
}
