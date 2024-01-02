using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBox : MonoBehaviour
{
    [SerializeField] Image _bg;
    [SerializeField] TextMeshProUGUI _text;
    private CanvasGroup _canvasGroup;
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void ShowText()
    {
        _canvasGroup.alpha = 1;
    }
    public void HideText()
    {
        _canvasGroup.alpha = 0;
    }
    public void PrintText(string t)
    {
        _text.text = t;
    }

}
