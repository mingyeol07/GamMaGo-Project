using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class MoveTable : MonoBehaviour
{
    [SerializeField] private Transform _leftMovePos;
    [SerializeField] private Transform _rightMovePos;
    [SerializeField] private Transform _upMovePos;

    [SerializeField] private GameObject _leftBtn;
    [SerializeField] private GameObject _rightBtn;
    [SerializeField] private GameObject _upBtn;

    [SerializeField] private CanvasGroup _MoveBtn;

    [SerializeField] private GameObject _helpPanel;
    [SerializeField] private GameObject[] _helpImage;
    [SerializeField] private GameObject _back;

    public void LeftMove()
    {
        _leftBtn.gameObject.SetActive(false);
        Camera.main.transform.DOMove(_leftMovePos.position, 0.3f);
        _rightBtn.gameObject.SetActive(true);
        _upBtn.gameObject.SetActive(false);
    }

    public void RightMove()
    {
        _rightBtn.gameObject.SetActive(false);
        Camera.main.transform.DOMove(_rightMovePos.position, 0.3f);
        _leftBtn.gameObject.SetActive(true);
        _upBtn.gameObject.SetActive(true);
    }

    public void UpMove()
    {
        _upBtn.gameObject.SetActive(false);
        Camera.main.transform.DOMove(_upMovePos.position, 0.3f);
        _leftBtn.gameObject.SetActive(false);
    }

    public void DownMove()
    {
        _rightBtn.gameObject.SetActive(false);
        Camera.main.transform.DOMove(_rightMovePos.position, 0.3f);
        _leftBtn.gameObject.SetActive(true);
        _upBtn.gameObject.SetActive(true);
    }

    public void OnOffBtn(CanvasGroup group)
    {
        if (group.alpha == 0)
        {
            group.alpha = 1;
            group.blocksRaycasts = true;
            group.interactable = true;
        }
        else
        {
            group.alpha = 0;
            group.blocksRaycasts = false;
            group.interactable = false;
        }


    }
    public void HelpPnael()
    {
        if (_helpPanel.activeSelf == false)
        {
            _helpPanel.gameObject.SetActive(true);
        }
        else _helpPanel.gameObject.SetActive(false);
    }

    public void helpImage()
    {
        if (_helpImage[0].activeSelf == true)
        {
            _helpImage[0].SetActive(false);
            _helpImage[1].SetActive(true);
            _helpImage[2].SetActive(false);
        }
        else if (_helpImage[1].activeSelf == true)
        {
            _helpImage[0].SetActive(false);
            _helpImage[1].SetActive(false);
            _helpImage[2].SetActive(true);
        }
        else if (_helpImage[2].activeSelf == true)
        {
            HelpPnael();
            _helpImage[0].SetActive(true);
            _helpImage[1].SetActive(false);
            _helpImage[2].SetActive(false);
        }
    }

    public void helpBack()
    {
        if (_helpImage[1].activeSelf == true)
        {
            _helpImage[0].SetActive(true);
            _helpImage[1].SetActive(false);
            _helpImage[2].SetActive(false);
        }
        else if (_helpImage[2].activeSelf == true)
        {
            HelpPnael();
            _helpImage[0].SetActive(false);
            _helpImage[1].SetActive(true);
            _helpImage[2].SetActive(false);
        }
    }

    public void ChapterBack()
    {
        if (_back.gameObject.activeSelf == true)
        {
            _rightBtn.gameObject.SetActive(false);
            Camera.main.transform.position = _rightMovePos.position;
            _leftBtn.gameObject.SetActive(true);
            _upBtn.gameObject.SetActive(true);
            _back.gameObject.SetActive(false);
        }
        else
        {
            _back.gameObject.SetActive(true);
        }
    }
}
