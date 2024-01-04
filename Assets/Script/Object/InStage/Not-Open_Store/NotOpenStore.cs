using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotOpenStore : TouchObject
{
    [SerializeField]
    TextList _idleText;
    
    [SerializeField]
    Sprite openStore;
    [SerializeField]
    bool isOpen = false;

 

    public ItemData Coffee;

    public override void ItemUsing(InventoryItem code)
    {
        return;
    }

    protected override void TouchEvent()
    {
        if (!isOpen)
        {
            isOpen = true;
            _renderer.sprite = openStore;
        }
        else
        {
            GameManager.ins.GetItems(Coffee);
        }
    }
}
