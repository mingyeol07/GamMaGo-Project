using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Bottle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 previousScale;
    private Vector3 previousRotation;

    private void Start()
    {
        previousRotation = new Vector3(0,0,0);
        previousScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DORotate(new Vector3(0, 0, -18), 0.4f);
        transform.DOScale(1.3f, 0.4f);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DORotate(previousRotation, 0.4f);
        transform.DOScale(previousScale, 0.4f);
    }
}

