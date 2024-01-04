using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    public int nowStage;
    public bool clearCondition = false;
    public bool[] clearStage;
    public GameObject effect;

    public Color color = Color.white;

    [Range(0, 16)]
    public int outlineSize = 1;

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
    private void Start()
    {
        nowStage = 3;
        Screen.SetResolution(1080, 1920, true);
    }
    //void OnPreCull() => GL.Clear(true, true, Color.black);

    public void ClearCheck()
    {
        if (clearCondition)
        {
            clearStage[nowStage] = true;
            clearCondition = false;
            
            nowStage = 3;
            BottleManager.ins.buttonOff();
            BottleManager.ins.SadBottle();

        }
        else clearCondition = true;
    }

    public void GetItems(params ItemData[] items)
    {
        foreach(ItemData data in items)
        {
            if(_inventory.GetItem(data))
            {
                UIManger.ins.Alert(data.Name, data.Version, data.img);
            }
        }
        
    }
    public void Update()
    {
        GameManager.ins.effect.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,5);
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
