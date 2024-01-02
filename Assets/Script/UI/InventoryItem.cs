using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _originParent;
    private GameObject _dragTransform;
    private void Awake()
    {
        _dragTransform = GameObject.Find("ItemVeiw");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _originParent = transform.parent;
        transform.SetParent(_dragTransform.transform);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit2D hit;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(pos, transform.forward, 1f);// hit
        if (hit) { print("hit"); }
        transform.SetParent(_originParent);
        transform.localPosition = Vector3.zero;
    }
}
