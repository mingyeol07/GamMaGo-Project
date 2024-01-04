using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UIManger : Singleton<UIManger>
{
    public bool isTextShow { get; private set; }
    [SerializeField] private TextBox _textBox;
    public Camera uiCamera;

    private bool _nowAlert;
    [SerializeField] private PopupPanel _popup;

    int _textIndex;
    TextList _textData;

    public event Action alertEvent;
    public event Action alertCloseEvent;
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
    }

    void PrintText()
    {
        StartCoroutine(
        _textBox.PrintText(_textData.Texts[_textIndex++], _textData.typingSpeed));
    }
    public void ShowText(TextList list)
    {
        alertEvent?.Invoke();
        InputManager.ins.SpaceKeyDown += NextText;
        if (!isTextShow)
        {
            isTextShow = true;
            _textData = list;
            _textIndex = 0;
            _textBox.ShowText();
            NextText();
        }
    }
    void HideText()
    {
        InputManager.ins.SpaceKeyDown -= NextText;
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

                    if(_textData.Event != string.Empty)
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
        //스택X 큐로
        if (!_nowAlert)
        {
            _nowAlert = true;
            alertEvent?.Invoke();
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
        alertEvent?.Invoke();
        if (_alertQueue.Count != 0)
        {
            AlertData alertData = _alertQueue.Dequeue();
            _popup.ShowPopup(alertData.title, alertData.desc, alertData.img);
        }
        else _popup.ShowPopup("Not Fount Data", string.Empty, null);
    }
    void HideAlert()
    {
        alertCloseEvent?.Invoke();
        _nowAlert = false;
        _popup.HidePopup();
    }
    public bool NoneAlert()
    {
        return !_nowAlert && !isTextShow;
    }
}
