using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yasinfirat;


public class ShopData : FileDataControl
{
    
    private  string FILENAME = "";

    ShopValues shopValues;

    public ShopData(string fileName) : base(fileName)
    {
        if (FILENAME.Length > 0)
            return;
        FILENAME = fileName;
    }

    public void ChechDataOnLoad(DataScriptable shopScriptable)
    {
        if (firstCreate)
        {
            data = new List<string>();
            
            for (int i = 0; i < shopScriptable.length; i++)
            {
                AddData(shopScriptable.defaultValueses[i]);
            }
            SaveData();
           
        }
    }
    
}
