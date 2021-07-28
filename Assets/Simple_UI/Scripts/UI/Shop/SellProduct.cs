using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellProduct
{
    public ShopValues shopValues;
    public int id;

    public SellProduct(int id)
    {
        this.id = id;
    }

    public bool SellThis()
    {
        shopValues = DataManager.Instance.shopDataController.getData.GetData(id);
        Debug.Log("sell " + (isAvaibleSell && !shopValues.isSold));
        if (isAvaibleSell&&!shopValues.isSold)
        {
            Debug.Log("SAtış işlemini gerçekleştir");
            //Buraya satış işlemini gerçekleştirecek kodu yazınız.
            
            DataManager.Instance.walletDataController.getData.Spend("Gold",shopValues.prices);
            DataManager.Instance.shopDataController.getData.SetSold(id,true);
            return true;
        }
        

        return false;
    }
    /// <summary>
    /// Ürün satılabilir olup olmadığını döndürür.
    /// </summary>
    public bool isAvaibleSell
    {
        get
        {
            return DataManager.Instance.walletDataController.getData.GetAmount("Gold") >= shopValues.prices;
        }
    }
    public bool isSold
    {
        get
        {
            return shopValues.isSold;
        }
    }
    

}
