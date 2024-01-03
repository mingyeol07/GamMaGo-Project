using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FollowItem : Singleton<FollowItem>
{
    private Image _image;
    public int item { get; private set; }
    public bool isItemDrag { get; private set; }
    protected override void Awake()
    {
        if (_ins == null)
        {
            _ins = this;
        }
        else Destroy(gameObject);
        _image = GetComponent<Image>();
    }
    private void Start()
    {
        HideFollow();
    }
    public void StartFollow(Sprite img,int code)
    {
        _image.enabled = true;
        _image.sprite = img;
        item = code;
    }
    public void HideFollow()
    {
        _image.enabled = false;
    }
}
