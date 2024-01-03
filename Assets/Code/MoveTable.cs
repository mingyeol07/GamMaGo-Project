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

    [SerializeField] private GameObject _inBtn;

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

    public void OnOffBtn()
    {
        if (_MoveBtn.alpha == 0)
        {
            _MoveBtn.alpha = 1;
            _MoveBtn.blocksRaycasts = true;
            _inBtn.gameObject.SetActive(false);
        }
        else
        {
            _MoveBtn.alpha = 0;
            _MoveBtn.blocksRaycasts = false;
            _inBtn.gameObject.SetActive(true);
        }
    }

    
}
