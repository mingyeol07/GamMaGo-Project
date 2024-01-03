using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
         if(eventData != null)
        {
            Debug.Log("ddddd");
        }
    }
}
