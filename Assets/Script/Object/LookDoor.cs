using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDoor : TouchObject
{
    [SerializeField] TextList _lookText;
    private bool _open;
    public override bool ItemUsing(int code)
    {
        throw new System.NotImplementedException();
    }

    protected override void TouchEvent()
    {
        UIManger.ins.ShowText(_lookText);
        //throw new System.NotImplementedException();
    }
}
