using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : TouchObject
{
    [SerializeField] ItemData _testItem;
    [SerializeField] ItemData _testItem2;
    protected override void Start()
    {
        base.Start();
        UIManger.ins.alertEvent += MouseExitEvent;
    }
    protected override void TouchEvent()
    {
        GameManager.ins.GetItems(_testItem, _testItem2);
    }
    public override bool ItemUsing(int code)
    {
        if (code.Equals(1))
        {
            return true;
        }
        return false;
    }
}
