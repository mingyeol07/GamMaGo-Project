using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Vector3 previousTransform;
    private Vector3 previousRotation;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = canvas.GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        previousRotation = new Vector3(0, 0, 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.DORotate(previousRotation, 0.4f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(transform.DORotate(new Vector3(0, 0, 10), 0.1f));
        mySequence.Append(transform.DORotate(new Vector3(0, 0, -8), 0.1f));
        mySequence.Append(transform.DORotate(new Vector3(0, 0, 6), 0.1f));
        mySequence.Append(transform.DORotate(new Vector3(0, 0, 0), 0.1f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
