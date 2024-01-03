using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Transform _stand;

    public void GetItems(params ItemData[] items)
    {
        foreach(ItemData data in items)
        {
            if(_inventory.GetItem(data))
            {
                UIManger.ins.Alert(data.name, data.Version, data.img);
                
            }
                
        }
    }
    //�ι��丮/���ӸŴ���,���/������ �ռ�/����Ʈ
}
