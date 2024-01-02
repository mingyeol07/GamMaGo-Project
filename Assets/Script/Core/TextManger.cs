using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManger : Singleton<TextManger>
{
    public bool IsTestShow { get; private set; }
    [SerializeField] TextBox _textBox;

    int textIndex;
    TextList TextData;

    void PrintText()
    {
        _textBox.PrintText(TextData.Texts[textIndex++]);
    }
    public void ShowText(TextList list)
    {
        if (!IsTestShow)
        {
            IsTestShow = true;
            TextData = list;
            textIndex = 0;
            _textBox.ShowText();
        }
    }
    void HideText()
    {
        IsTestShow = false;
        _textBox.HideText();
    }
    private void Start()
    {
        HideText();
        InputManager.ins.SpaceKeyDown += NextText;
    }
    private void NextText()
    {
        if (IsTestShow)
        {
            if (textIndex >= TextData.Texts.Length)
            {
                HideText();

                Eventbus.EventInvoke(TextData.Event);
            }
            else
            {
                PrintText();
            }
        }
    }
}
