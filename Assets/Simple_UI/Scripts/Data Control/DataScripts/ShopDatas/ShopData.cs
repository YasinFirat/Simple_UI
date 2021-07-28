using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yasinfirat;


public class ShopData : FileDataControl
{
    public ShopValues shopValues;
   
    private  string FILENAME = "";
    public ShopData(string fileName) : base(fileName)
    {
        if (FILENAME.Length > 0)
            return;
        FILENAME = fileName;
    }

    public ShopData ChechDataOnLoad(ShopDataController shopScriptable)
    {
        //ilk defa çalıştırılırsa aşağıdaki if bloğu çalışır.
        if (firstCreate)
        {
            data = new List<string>();
            Debug.Log("Data Boyut: " + shopScriptable.length);
            
            for (int i = 0; i < shopScriptable.length; i++)
            {
                shopScriptable.shopProducts[i].shopValues.id = i;
                AddData(shopScriptable.shopProducts[i].shopValues);
            }
            SaveData();
           
        }
        return this;
    }
    #region Gets
    /// <summary>
    /// Seçim durumu olup olmadığını belirtir.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool GetSelected(int index)
    {
        shopValues = WriteData<ShopValues>(index); //data sınıfa aktarılır.
        return shopValues.isSelected; //data döndürülür.
    }
    public bool GetSold(int index)
    {
        shopValues = WriteData<ShopValues>(index); //data sınıfa aktarılır.
        return shopValues.isSold; //data döndürülür.
    }
    public float GetPrice(int index)
    {
        shopValues = WriteData<ShopValues>(index); //data sınıfa aktarılır.
        return shopValues.prices; //data döndürülür.
    }
    public string GetName(int index)
    {
        shopValues = WriteData<ShopValues>(index); //data sınıfa aktarılır.
        return shopValues.name; //data döndürülür.
    }
    public int GetID(int index)
    {
        shopValues = WriteData<ShopValues>(index); //data sınıfa aktarılır.
        return shopValues.id; //data döndürülür.
    }
    public ShopValues GetData(int index)
    {
        return WriteData<ShopValues>(index);
    }
    public Sprite GetImage(int index)
    {
        shopValues = WriteData<ShopValues>(index); //data sınıfa aktarılır.
        return shopValues.image; //data döndürülür.
    }
    #endregion
    #region Sets
    /// <summary>
    /// Datayı seçili hale getirir. Seçili halde olan başka data varsa onun seçimini kaldırır.
    /// </summary>
    /// <param name="index"> Seçili hale gelecek data indexi </param>
    /// <param name="newValue">seçim durumu</param>

    public ShopData SetSelected(int index, bool newValue)
    {
        ReadAllData();

        shopValues = WriteData<ShopValues>(index);
        shopValues.isSelected = newValue;
        
        ChangeData(shopValues, index);
        SaveData();
        return this;
    }
    /// <summary>
    /// Satış durumu belirlenir.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="newValue">satış durumu</param>
    public ShopData SetSold(int index, bool newValue)
    {
        ReadAllData();
        shopValues = WriteData<ShopValues>(index);
        shopValues.isSold = newValue;
        ChangeData(shopValues, index);
        SaveData();
        return this;
    }
    public ShopData SetPrice(int index, float newValue)
    {
        ReadAllData();
        shopValues = WriteData<ShopValues>(index);
        shopValues.prices = newValue;
        ChangeData(shopValues, index);

        SaveData();
        return this;
    }
    public ShopData SetName(int index, string newValue)
    {
        ReadAllData();
        shopValues = WriteData<ShopValues>(index);
        shopValues.name = newValue;
        ChangeData(shopValues, index);

        SaveData();
        return this;
    }
    public ShopData SetPrice(int index, Sprite newImage)
    {
        ReadAllData();
        shopValues = WriteData<ShopValues>(index);
        shopValues.image = newImage;
        ChangeData(shopValues, index);
        
        SaveData();
        return this;
    }
    #endregion

    #region Finds
    /// <summary>
    /// İstenilen durumdaki tüm dataları listeler.
    /// </summary>
    /// <param name="isSelect">istenilen durum</param>
    /// <returns></returns>
    public int findSelectedId
    {
        get
        {
            int count=0;
            ReadAllData();
           
            for (int i = 0; i < data.Count; i++)
            {
                if (GetSelected(i))
                {
                    count = i;
                    break;
                }
            }
            return count;
        }
    }
    #endregion
}
