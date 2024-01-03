using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public int itemCode;
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform previousPos;

    private void Awake()
    {
        previousPos = GetComponent<Transform>();
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = canvas.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        previousPos.position = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TweenRotation();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TweenRotation();
    }

    private void TweenRotation()
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(transform.DORotate(new Vector3(0, 0, 10), 0.1f));
        mySequence.Append(transform.DORotate(new Vector3(0, 0, -8), 0.1f));
        mySequence.Append(transform.DORotate(new Vector3(0, 0, 6), 0.1f));
        mySequence.Append(transform.DORotate(new Vector3(0, 0, 0), 0.1f));
    }

    public void OnDrop(PointerEventData eventData)
    {
        InPot();
        Debug.Log("dd");
    }

    public void InPot()
    {
        Sequence mySequence = DOTween.Sequence();
        
        
    }
}
