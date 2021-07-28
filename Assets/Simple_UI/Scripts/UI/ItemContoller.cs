using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data'dan alınan verileri gridlere dağıtır.
/// </summary>

public class ItemContoller : MonoBehaviour
{
    [Tooltip("DataScriptable'den türeyen bir nesneyi sürükleyin.(Sadece boyutuna ihtiyacımız var :))")]
    public DataScriptable dataScriptable;
    [Tooltip("GridControl scriptinin tanımlı olduğu objeyi sürükleyin.")]
    public GridControl gridControl;
    public List<GridItem> gridItems;
    private int lenghtOfGridItems;
  
    
    private void Awake()
    {
        lenghtOfGridItems = dataScriptable.length; //data boyutu tespit edilirse
        gridControl.CreateGridMember(lenghtOfGridItems);
        for (int i = 0; i < lenghtOfGridItems; i++)
        {
            gridItems.Add(gridControl.gridMember.GetComponent<GridItem>(i));
        }
    }
    private void OnEnable()
    {
        //Obje her aktif olduğunda çalışır.
        CheckGridMembers();
    }
    /// <summary>
    /// Veriler kontrol edilir ve aktarma yapılır.
    /// </summary>
    public void CheckGridMembers()
    {
        //level yerleştirmesi yapılacak yapılacak.
        for (int i = 0; i < lenghtOfGridItems; i++)
        {
            gridItems[i].SetInformations(this,i);
        }
    }
}
