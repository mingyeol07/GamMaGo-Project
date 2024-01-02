using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TouchObgect : MonoBehaviour,IDropHandler
{
    [SerializeField] Sprite Idle_img;
    [SerializeField] Sprite OnMouse_img;

    [SerializeField] TextList a;
    [SerializeField] ItemData item;
    private SpriteRenderer render;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {        
        Eventbus.GetEvent(1, ()=> GameManager.ins.GetItem(item));
    }
    private void OnMouseEnter()
    {
        render.sprite = OnMouse_img;
    }
    private void OnMouseExit()
    {
        render.sprite = Idle_img;
    }
    private void OnMouseDown()
    {
        if (GameManager.ins.NoneAlert())
            TextManger.ins.ShowText(a);
    }
    private void OnMouseUp()
    {
        
    }
    private void TouchEvent()
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
        print("aaa");
    }
}
