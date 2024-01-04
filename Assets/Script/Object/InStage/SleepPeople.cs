using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepPeople : TouchObject
{
    [SerializeField]
    TextList _idleText;
    [SerializeField]
    bool isAngry;
    [SerializeField]
    Sprite Angry;

    private void Start()
    {
        base.Start();
        isAngry = false;
        Eventbus.GetEvent("Set Angry", () => {
            _renderer.sprite = Angry;
        }
        );
    }
    public override void ItemUsing(InventoryItem code)
    {
        MouseExitEvent();
        if ((code.item.itemCode) == Item.MedicioneIcecream)
        {
            code.DeleteItem();
            isAngry = true;
            Eventbus.EventInvoke("Set Angry");
        }
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_idleText);
    }
}
