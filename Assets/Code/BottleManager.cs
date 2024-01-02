using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BottleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] chapterPrefab;

    public void LoadChapter(int chapterNumber)
    {
        chapterPrefab[chapterNumber].gameObject.transform.DOScale(0f, 0.4f);

        chapterPrefab[chapterNumber].gameObject.transform.DOLocalRotate(new Vector3(0f, 0f, 200f), 1f);
        Camera.main.transform.position = new Vector3(chapterPrefab[chapterNumber].transform.position.x,
            chapterPrefab[chapterNumber].transform.position.y, -10);
        for (int i = 0; i < chapterPrefab.Length; i++)
        {
            
            //Sequence mySequence = DOTween.Sequence();
            //mySequence.Append();
        }
    }
}
