using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Market : TouchObject
{
    [SerializeField]
    TextList _idleText;
    [SerializeField]
    ItemData _iceCream;
    [SerializeField]
    Sprite CloseMarket;
    [SerializeField]
    GameObject Graffiti;

    private void Start()
    {
        Eventbus.GetEvent("Set Angry", () => {
            _renderer.sprite = CloseMarket;
        }
        );
    }

    public override void ItemUsing(InventoryItem code)
    {
        if (code.item.itemCode == Item.Coin)
        {
            GameManager.ins.GetItems(_iceCream);
            code.DeleteItem();


        }
        else if (code.item.itemCode == Item.Spray)
        {
            Graffiti.SetActive(true);
            code.DeleteItem();
        }
        
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_idleText);
    }
}
