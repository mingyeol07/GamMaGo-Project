using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[AddComponentMenu("devchanho/TouchObject")]
public abstract class TouchObject : MonoBehaviour
{
    [SerializeField] protected Item[] _interactionItem;
    private static GameObject _effect;
    //GameObject _particle;
    protected Vector3 _originPos { get; private set; }
    protected SpriteRenderer _renderer { get; private set; }
    
    protected virtual void Awake()
    {
        _originPos = transform.position;
        if (_effect == null)
        {
            _effect = GameObject.Find("MouseOnEffect");
            _effect.SetActive(false);
        }
        _renderer = GetComponent<SpriteRenderer>();
    }
    protected virtual void Start()
    {
        MouseExitEvent();
        UIManger.ins.alertEvent += MouseExitEvent;
        //_particle = transform.GetChild(0).gameObject;
    }
    private void OnMouseEnter()
    {
        
        if (UIManger.ins.NoneAlert())
            if (FollowItem.ins.isItemDrag) MouseEnterEvent((int)FollowItem.ins.item.item.itemCode);
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
            transform.DOScale(1.1f, 0.1f);
            //_particle.SetActive(true);
        }
        else
        {
            if(Array.Exists(_interactionItem,x => x == FollowItem.ins.item.item.itemCode))
            {
                transform.DOScale(1.1f, 0.1f);
                //_particle.SetActive(true);
            }
        }
    }
    protected virtual void MouseExitEvent() 
    {
        transform.DOScale(1.0f, 0.1f);
        //_particle.SetActive(false);
    }
    protected abstract void TouchEvent();
    public abstract void ItemUsing(InventoryItem code);
}