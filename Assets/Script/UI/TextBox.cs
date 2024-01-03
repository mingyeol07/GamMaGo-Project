using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class TextBox : MonoBehaviour
{
    [SerializeField] Image _bg;
    [SerializeField] TextMeshProUGUI _text;
    private string _textStr;
    private CanvasGroup _canvasGroup;
    public bool isTyping { get; private set; }

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
    public IEnumerator PrintText(string text,float typingSpeed)
    {
        _textStr = text;
        isTyping = true;
        for (int i = 0;i < _textStr.Length+1;i++)
        {
            if (!isTyping) break;
            _text.text = _textStr.Substring(0,i);
            yield return new WaitForSeconds(1 / typingSpeed);
        }
        isTyping = false;
        //_text.
        //_text.text = text;
    }
    public void TypingSkip()
    {
        StopCoroutine("PrintText");
        _text.text = _textStr;
        isTyping = false;
    }
}
