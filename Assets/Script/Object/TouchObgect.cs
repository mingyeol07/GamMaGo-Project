using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TouchObgect : MonoBehaviour
{
    [SerializeField] Sprite Idle_img;
    [SerializeField] Sprite OnMouse_img;

    [SerializeField] TextList _eventText;
    [SerializeField] ItemData _item;
    private SpriteRenderer _renderer;
    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {        
        Eventbus.GetEvent(1, ()=> {
            //Inventory.ins.GetItem(_item);
            //Inventory.ins.GetItem(_item);
            UIManger.ins.Alert("Hello world",string.Empty,null);
            UIManger.ins.Alert("And...",string.Empty,null);
            UIManger.ins.Alert("Hello Unity!",string.Empty,null);
        });
    }
    private void OnMouseEnter()
    {
        _renderer.sprite = OnMouse_img;
    }
    private void OnMouseExit()
    {
        _renderer.sprite = Idle_img;
    }
    private void OnMouseDown()
    {
        UIManger.ins.ShowText(_eventText);
    }
    private void TouchEvent()
    {
        print("aaa");
    }

    public bool ItemUsing(int code)
    {
        return true;
    }
}
