using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveTable : MonoBehaviour
{
    [SerializeField] private Transform _leftMovePos;
    [SerializeField] private Transform _rightMovePos;
    [SerializeField] private GameObject _leftBtn;
    [SerializeField] private GameObject _rightBtn;

    [SerializeField] private CanvasGroup _inBtn;

    [SerializeField] private CanvasGroup _MoveBtn;

    public void LeftMove()
    {
        _leftBtn.gameObject.SetActive(false);
        Camera.main.transform.DOMove(_leftMovePos.position, 0.3f);
        _rightBtn.gameObject.SetActive(true);
    }

    public void RightMove()
    {
        _rightBtn.gameObject.SetActive(false);
        Camera.main.transform.DOMove(_rightMovePos.position, 0.3f);
        _leftBtn.gameObject.SetActive(true);
    }

    public void OnOffBtn(CanvasGroup group)
    {
        if (group.alpha == 0)
        {
            group.alpha = 1;
            group.blocksRaycasts = true;
            _inBtn.alpha = 1;
            _inBtn.interactable = true;
            _MoveBtn.gameObject.SetActive(false);
        }
        else
        {
            group.alpha = 0;
            group.blocksRaycasts = false;
            _inBtn.alpha = 0;
            _inBtn.interactable = false;
            _MoveBtn.gameObject.SetActive(true);
        }
    }
    
    public void OnOffBackBtn()
    {
        if (_inBtn.interactable)
            _inBtn.interactable = false;
        else _inBtn.interactable = true;
    }
}
