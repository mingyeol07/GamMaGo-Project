using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public abstract class TouchObject : MonoBehaviour
{
    [SerializeField] Sprite Idle_img;
    [SerializeField] Sprite OnMouse_img;
    protected SpriteRenderer _renderer { get; private set; }
    protected Vector3 _originPos { get; private set; }
    
    protected virtual void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _originPos = transform.position;
    }
    protected virtual void Start()
    {
        MouseExitEvent();
    }
    //{        
    //    Eventbus.GetEvent(1, ()=> {
    //        //Inventory.ins.GetItem(_item);
    //        //Inventory.ins.GetItem(_item);
    //        UIManger.ins.Alert("Hello world");
    //        UIManger.ins.Alert("And...");
    //        UIManger.ins.Alert("Hello Unity!");
    //    });
    //}
    private void OnMouseEnter()
    {
        
        if (UIManger.ins.NoneAlert())
            if (FollowItem.ins.isItemDrag) MouseEnterEvent(FollowItem.ins.item);
            else MouseEnterEvent(0);

    }
    private void OnMouseExit()
    {
        if (UIManger.ins.NoneAlert())
            MouseExitEvent();
    }
    private void OnMouseDown()
    {
        if (UIManger.ins.NoneAlert())
            TouchEvent();
    }
    protected virtual void MouseEnterEvent(int code)
    {
        transform.DOScale(1.2f, 0.2f);
        //transform.DOShakePosition(3).SetDelay(3.0f);;
        _renderer.sprite = OnMouse_img;
    }
    protected virtual void MouseExitEvent() 
    {
        transform.DOScale(1.0f, 0.2f);
        _renderer.sprite = Idle_img;
    }
    protected abstract void TouchEvent();
    //{
    //    UIManger.ins.ShowText(_eventText);
    //    print("aaa");
    //}
    public abstract bool ItemUsing(int code);
    //{
    //    return true;
    //}
    //FollowItem °¨Áö
}
