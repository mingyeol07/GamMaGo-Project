using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FollowItem : Singleton<FollowItem>
{
    private Image _image;
    public InventoryItem item;//{ get; private set; }
    public bool isItemDrag;//{ get; private set; }
    protected override void Awake()
    {
        if (_ins == null)
        {
            _ins = this;
        }
        else Destroy(gameObject);
        _image = GetComponent<Image>();
        isItemDrag = false;
    }
    private void Start()
    {
        HideFollow();
    }
    public void StartFollow(Sprite img,InventoryItem code)
    {
        _image.enabled = true;
        _image.sprite = img;
        item = code;
        isItemDrag = true;
    }
    public void HideFollow()
    {
        _image.enabled = false;
        isItemDrag = false;
    }
}
