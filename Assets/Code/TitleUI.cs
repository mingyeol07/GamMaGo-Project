using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private GameObject soundPanel;
    [SerializeField] private Transform startPos;
    [SerializeField] private GameObject helpPanel;

    public void StartBtn()
    {
        Camera.main.transform.DOMove(startPos.position, 0.2f);
    }

    public void SoundPanel()
    {
        if(soundPanel.transform.localScale.x == 0)
        {
            soundPanel.transform.DOScale(0.425f, 0.2f);
        }
        else soundPanel.transform.DOScale(0, 0.3f);
    }

    public void Help()
    {
        if (helpPanel.transform.localScale.x == 0)
        {
            helpPanel.transform.DOScale(1f, 0.2f);
        }
        else helpPanel.transform.DOScale(0, 0.2f);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
