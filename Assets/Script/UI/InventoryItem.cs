using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IDropHandler,IPointerEnterHandler, IPointerExitHandler
{
    //[SerializeField] private Transform _originParent;
    //private static GameObject _dragTransform;
    private Image _image;
    public ItemData item { get; private set; }
    public event Action useEvent;

    private void Awake()
    {
        //if(_dragTransform == null) _dragTransform = GameObject.Find("ItemVeiw");
        _image = GetComponent<Image>();
    }
    //private void OnMouseEnter()
    //{
    //    print("Enter");
    //}
    public void OnBeginDrag(PointerEventData eventData)
    {
        FollowItem.ins.StartFollow(_image.sprite,this);
        _image.enabled = false;
        //_image.raycastTarget = false;
        //_originParent = transform.parent;
        //_image.color = new Color(1f,1f,1f,0.2f);
        //transform.SetParent(_dragTransform.transform);
    }
    public void OnDrag(PointerEventData eventData)
    {
        FollowItem.ins.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.SetParent(_originParent);
        FollowItem.ins.HideFollow();
        RaycastHit2D hit;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(pos, transform.forward, 1f);// hit
        if (hit)
        {
            //print("hit"); 
            UseItem(hit.transform.gameObject.GetComponent<TouchObject>());
        }

        _image.enabled = true;
        //_image.raycastTarget = true;
        //_image.color = new Color(1f, 1f, 1f, 1f);
        //transform.localPosition = Vector3.zero;
    }
    public void OnDrop(PointerEventData eventData)
    {
        int itemCode = FollowItem.ins.item.item.itemCode;
        ItemData itemData = GameManager.ins.ItemSynthesis(item.itemCode, itemCode);
        if (itemData != null)
        {
            GameManager.ins.GetItems(itemData);

            FollowItem.ins.HideFollow();
            FollowItem.ins.item.DeleteItem();
            DeleteItem();
        }
    }
    public void DeleteItem()
    {
        DOTween.Kill(transform);
        useEvent?.Invoke();
        //Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
    public void UseItem(TouchObject obj)
    {
        obj.ItemUsing(this);
            //DeleteItem();
    }
    public void SetData(ItemData code,Sprite img)
    {
        item = code;
        _image.sprite = img;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!FollowItem.ins.isItemDrag)
            transform?.DOScale(1.2f,0.2f);
        //print("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform?.DOScale(1.0f, 0.2f);
        //print("Exit");
    }
}
