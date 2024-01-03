using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    private RectTransform rect;

    public void OnDrop(PointerEventData eventData)
    {

        Debug.Log("Dd");
        
    }
}
