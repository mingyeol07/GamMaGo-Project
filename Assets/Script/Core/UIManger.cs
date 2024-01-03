using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManger : Singleton<UIManger>
{
    public bool isTextShow { get; private set; }
    [SerializeField] private TextBox _textBox;

    private bool _nowAlert;
    [SerializeField] private PopupPanel _popup;

    int _textIndex;
    TextList _textData;
    private struct AlertData
    {
        public string title;
        public string desc;
        public Sprite img;
        public AlertData(string title)
        {
            this.title = title;
            this.desc = string.Empty;
            this.img = null;
        }
        public AlertData(string title, string desc)
        {
            this.title = title;
            this.desc = desc;
            this.img = null;
        }
        public AlertData(string title, string desc, Sprite img)
        {
            this.title = title;
            this.desc = desc;
            this.img = img;
        }
        public AlertData(Sprite img)
        {
            this.title = string.Empty;
            this.desc = string.Empty;
            this.img = img;
        }
        public AlertData(string title,Sprite img)
        {
            this.title = title;
            this.desc = string.Empty;
            this.img = null;
        }
    }
    Queue<AlertData> _alertQueue = new Queue<AlertData>();
    private void Start()
    {
        HideText();
        HideAlert();
        InputManager.ins.SpaceKeyDown += NextText;
    }

    void PrintText()
    {
        StartCoroutine(
        _textBox.PrintText(_textData.Texts[_textIndex++], _textData.typingSpeed));
    }
    public void ShowText(TextList list)
    {
        if (!isTextShow)
        {
            isTextShow = true;
            _textData = list;
            _textIndex = 0;
            _textBox.ShowText();
        }
    }
    void HideText()
    {
        isTextShow = false;
        _textBox.HideText();
    }
    private void NextText()
    {
        if (isTextShow)
        {
            if (_textBox.isTyping) _textBox.TypingSkip();
            else
            {
                if (_textIndex >= _textData.Texts.Length)
                {
                    HideText();

                    Eventbus.EventInvoke(_textData.Event);
                }
                else
                {
                    PrintText();
                }
            }
            
        }
    }
    public void Alert(string title, string desc,Sprite img)
    {
        _alertQueue.Enqueue(new AlertData(title, desc, img));
        //����X ť��
        if (!_nowAlert)
        {
            _nowAlert = true;
            ShowAlert();
        }
    }
    public void Alert(string title, string desc)
    {
        Alert(title, desc, null);
    }
    public void Alert(string title)
    {
        Alert(title, string.Empty, null);
    }
    public void Alert(string title, Sprite img)
    {
        Alert(title, string.Empty, img);
    }
    public void Alert(Sprite img)
    {
        Alert(string.Empty, string.Empty, img);
    }
    public void Alert(AlertDocument data)
    {
        Alert(data.title, data.desc, data.img);
    }
    public void ExitAlert()
    {
        if (_alertQueue.Count != 0)
            ShowAlert();
        else HideAlert();
    }
    void ShowAlert()
    {
        if (_alertQueue.Count != 0)
        {
            AlertData alertData = _alertQueue.Dequeue();
            _popup.ShowPopup(alertData.title, alertData.desc, alertData.img);
        }
        else _popup.ShowPopup("Not Fount Data", string.Empty, null);
    }
    void HideAlert()
    {
        _nowAlert = false;
        _popup.HidePopup();
    }
    public bool NoneAlert()
    {
        return !_nowAlert && !isTextShow;
    }
}