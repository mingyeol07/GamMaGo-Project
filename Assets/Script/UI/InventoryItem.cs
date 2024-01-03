using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IDropHandler
{
    //[SerializeField] private Transform _originParent;
    //private static GameObject _dragTransform;
    private Image _image;
    private int item;
    public event Action useEvent;

    private void Awake()
    {
        //if(_dragTransform == null) _dragTransform = GameObject.Find("ItemVeiw");
        _image = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        FollowItem.ins.StartFollow(_image.sprite,item);
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
            UseItem(hit.transform.gameObject.GetComponent<TouchObgect>());
        }

        _image.enabled = true;
        //_image.raycastTarget = true;
        //_image.color = new Color(1f, 1f, 1f, 1f);
        //transform.localPosition = Vector3.zero;
    }
    public void OnDrop(PointerEventData eventData)
    {
        print($"{FollowItem.ins.item}");
    }
    private void UseItem(TouchObgect obj)
    {
        if (obj.ItemUsing(item))
        {
            useEvent?.Invoke();
            //Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
    public void SetData(int code,Sprite img)
    {
        item = code;
        _image.sprite = img;
    }
}
