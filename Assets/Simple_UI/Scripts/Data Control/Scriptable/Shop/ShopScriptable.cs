using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShopDatas",menuName ="Data/Shop",order =2)]
public class ShopScriptable :DataScriptable
{
    public new void CheckOnLoad()
    {
        length = defaultValueses.Count;
        ((ShopData)data).ChechDataOnLoad(this);
    }
    
    public new void CreateData()
    {
        data = new ShopData(fileName);
        
    }
   
    public new ShopData getData
    {
        get
        {
            return ((ShopData)base.getData);
        }
    } 
}
