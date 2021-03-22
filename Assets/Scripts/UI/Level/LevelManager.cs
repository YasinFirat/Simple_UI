using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yasinfirat;


public class LevelManager : MonoBehaviour
{
    private GridControl gridControl;
    [HideInInspector]public List<GridItem> levelItem;
    private int totalLevel;
    public Files data;
    
    private void Awake()
    {
        DataManager dataManager = FindObjectOfType<DataManager>();
        gridControl = transform.GetComponentInChildren<GridControl>();
        
        totalLevel = dataManager.GetDataClass(data).ReadAllData().Count;
        gridControl.CreateGridMember(totalLevel);
        
        for (int i = 0; i < totalLevel; i++)
        {
            levelItem.Add(gridControl.gridMember.GetComponent<GridItem>(i));
        }
    }
    private void OnEnable()
    {
        CheckGridMembers();
    }
    public void CheckGridMembers()
    {
        //level yerleştirmesi yapılacak yapılacak.
        for (int i = 0; i < totalLevel; i++)
        {
            levelItem[i].SetInformations();
        }
    }
}
