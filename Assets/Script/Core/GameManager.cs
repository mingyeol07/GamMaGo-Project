using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Inventory _inventory;
    [Serializable]
    struct ItemRecipe
    {
        public Item mat1, mat2;
        public ItemData result;
        //public ItemRecipe(int mat1, int mat2, ItemData result)
        //{
        //    this.mat1 = mat1;
        //    this.mat2 = mat2;
        //    this.result = result;
        //}
    }
    [SerializeField]
    ItemRecipe[] ItemRecipes;

    public void GetItems(params ItemData[] items)
    {
        foreach(ItemData data in items)
        {
            if(_inventory.GetItem(data))
                UIManger.ins.Alert(data.Name,data.Version,data.img);
        }
    }
    public ItemData ItemSynthesis(Item mat1, Item mat2)
    {
        if (ItemRecipes != null && ItemRecipes.Length > 0)
        {
            int _index = Array.FindIndex(ItemRecipes, x =>
            {
                print($"x.mat1:{x.mat1}, mat1:{mat1}, x.mat2:{(x.mat2)}, mat2:{mat2}");
                return (x.mat1 == mat1 && (x.mat2) == mat2) || ((x.mat1) == mat2 && (x.mat2) == mat1);
            });
            if (_index != -1) return ItemRecipes[_index].result;
        }
        return null;
    }
    //인번토리/게임매니자,상속/아이템 합성/이펙트
}
