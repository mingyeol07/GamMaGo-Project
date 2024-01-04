using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : TouchObject
{
    [SerializeField] TextList _touchText;
    private bool _carIsSetting = false;
    protected override void Start()
    {
        base.Start();
        Eventbus.GetEvent("Police Gone", () => {
            gameObject.SetActive(false);
            if (GameManager.ins.nowStage == 0) GameManager.ins.ClearCheck();
         });
        Eventbus.GetEvent("Set PoliceCar", () => _carIsSetting = true) ;
        _carIsSetting = false;
    }
    public override void ItemUsing(InventoryItem code)
    {
        return;
        MouseExitEvent();
        if (code.item.itemCode == Item.SmartPon)
        {
            code.DeleteItem();
            //Eventbus.EventInvoke("Police Gone");
        }
    }

    protected override void TouchEvent()
    {
        if(!_carIsSetting)
            UIManger.ins.ShowText(_touchText);
        else Eventbus.EventInvoke("Police Gone");
    }
}
