using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
//[AddComponentMenu("devchanho/TouchObject")]
public abstract class TouchObject : MonoBehaviour
{
    [SerializeField] protected Item[] _interactionItem;
    [SerializeField] protected GameObject _effect;
    //private static GameObject _effect;
    //GameObject _particle;
    protected Vector3 _originPos { get; private set; }
    protected SpriteRenderer _renderer { get; private set; }
    protected SpriteOutLine _outLine { get; private set; }
    //[SerializeField] private GameObject _effect;

    protected virtual void Awake()
    {
        _originPos = transform.position;
        //if (_effect == null)
        {
            //_effect = GameObject.Find("MouseOnEffect");
            //_effect.SetActive(false);
        }
        _renderer = GetComponent<SpriteRenderer>();
        _outLine = GetComponent<SpriteOutLine>();
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
    void EffectOnOff(bool on)
    {
        GameManager.ins.effect.SetActive(on);
    }
    protected virtual void MouseEnterEvent(int code)
    {
        if (!FollowItem.ins.isItemDrag || Array.Exists(_interactionItem, x => x == FollowItem.ins.item.item.itemCode))
        {
            _outLine.enabled = true;
            transform.DOScale(1.1f, 0.1f);
            EffectOnOff(true);
            //_particle.SetActive(true);
        }
    }
    protected virtual void MouseExitEvent() 
    {
        _outLine.enabled = false;
        transform.DOScale(1.0f, 0.1f);
        EffectOnOff(false);
        //_particle.SetActive(false);
    }
    protected abstract void TouchEvent();
    public abstract void ItemUsing(InventoryItem code);
    protected void SetEffect()
    {
        UIManger.ins.alertCloseEvent += Effect;
    }
    private void Effect()
    {
        GameObject effect = Instantiate(_effect);
        effect.transform.position = new Vector3(transform.position.x,transform.position.y,-5);
        effect.GetComponent<EffectMove>()._tar = new Vector3(12,0,-5);
        UIManger.ins.alertCloseEvent -= Effect;
    }
}