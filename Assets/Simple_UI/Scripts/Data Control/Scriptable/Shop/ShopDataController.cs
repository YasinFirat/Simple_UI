using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShopDatas",menuName ="Data/Shop/ShopController",order =1)]
public class ShopDataController :DataScriptable
{
  
    private ShopData shopData;
    public List<ShopProduct> shopProducts;

    public ShopData getData
    {
        get
        {
            return shopData;
        }
        private set { }
    }
    public override void CheckOnLoad()
    {
        Debug.Log("Check is " + fileName + "boyut " + shopProducts.Count);
        length = shopProducts.Count;
        shopData.ChechDataOnLoad(this);
        if (!shopData.FirstCreate())
        {
            UpdateDatas();
        }
        
    }
    public ShopDataController UpdateDatas()
    {
        for (int i = 0; i < length; i++)
        {
            shopProducts[i].shopValues = shopData.GetData(i);
        }
        return this;
    }
    public override void CreateData()
    {
        Debug.Log("Create is " +fileName);
        shopData = new ShopData(fileName);
    }
    public override int length => base.length;
}
