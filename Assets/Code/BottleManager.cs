using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class BottleManager : Singleton<BottleManager>
{
    [SerializeField] private GameObject[] chapterPrefab;
    [SerializeField] private GameObject[] chapterJoin;
    [SerializeField] private Sprite[] sadFace;
    [SerializeField] private bool[] chat;
    [SerializeField] private TextList[] IntroChat;
    [SerializeField] private TextList[] OutroChat;
    [SerializeField] private GameObject[] _char;

    private void Start()
    {
        Eventbus.GetEvent("ChatOff", () => _char[GameManager.ins.nowStage].SetActive(false));
    }

    public void LoadChapter(int chapterNumber)
    {
        if (GameManager.ins.clearStage[chapterNumber] == false || GameManager.ins.nowStage == 3)
        {
            GameManager.ins.nowStage = chapterNumber;
            chapterPrefab[chapterNumber].gameObject.SetActive(true);

            buttonOff();

            Camera.main.transform.position = new Vector3(chapterPrefab[chapterNumber].transform.position.x, 0, -10);
            if (chat[chapterNumber] == false)
            {
                chat[chapterNumber] = true;
                UIManger.ins.ShowText(IntroChat[chapterNumber]); _char[chapterNumber].SetActive(true);
            }
        }

        for (int i = 0; i < chapterPrefab.Length; i++)
        {
            
            //Sequence mySequence = DOTween.Sequence();
            //mySequence.Append();
        }
    }
    
    public void SadBottle()
    {
        for (int i = 0; i < chapterJoin.Length; i++)
        {
            if (GameManager.ins.clearStage[i] == true)
            {
                chapterJoin[i].GetComponent<Image>().sprite = sadFace[i];
            }
        }
       
    }

    public void buttonOff()
    {
        for (int i = 0; i < chapterPrefab.Length; i++)
        {
            if (i != GameManager.ins.nowStage)
            {
                chapterJoin[i].GetComponent<Button>().enabled = false;
               // chapterJoin[i].GetComponent<Image>().color = new Color(255, 255, 255, 100);
            }
            if (GameManager.ins.nowStage == 3)
            {
                chapterJoin[i].GetComponent<Button>().enabled = true;
               // chapterJoin[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
        }
    }
}
