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

    [SerializeField] private CanvasGroup _MoveBtn;


    private void Update()
    {
        
    }

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

    public void StartMove()
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
            _MoveBtn.gameObject.SetActive(false);
        }
        else
        {
            group.alpha = 0;
            group.blocksRaycasts = false;
            _MoveBtn.gameObject.SetActive(true);
        }
    }
}
