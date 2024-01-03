using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public abstract class TouchObject : MonoBehaviour
{
    [SerializeField] Sprite _idle_img;
    [SerializeField] Sprite _onMouse_img;
    [SerializeField] Sprite _onItem_img;
    [SerializeField] protected int[] _interactionItem;
    protected SpriteRenderer _renderer { get; private set; }
    private SpriteOutLine _lineRenderer;
    [SerializeField] GameObject _particle;
    protected Vector3 _originPos { get; private set; }
    
    protected virtual void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _lineRenderer = GetComponent<SpriteOutLine>();
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
        if (!FollowItem.ins.isItemDrag)
        {
            transform.DOScale(1.2f, 0.1f);
            _lineRenderer.enabled = true;
            _particle.SetActive(true);
            //transform.DOShakePosition(3).SetDelay(3.0f);;
            _renderer.sprite = _onMouse_img;
        }
        else
        {
            if(Array.Exists(_interactionItem,x => x == FollowItem.ins.item))
            {
                //transform.DOScale(1.2f, 0.2f);
                //transform.DOShakePosition(3).SetDelay(3.0f);;
                _lineRenderer.enabled = true;
                _particle.SetActive(true);
                _renderer.sprite = _onItem_img;
            }
        }
    }
    protected virtual void MouseExitEvent() 
    {
        _lineRenderer.enabled = false;
        _particle.SetActive(false);
        transform.DOScale(1.0f, 0.1f);
        _renderer.sprite = _idle_img;
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
