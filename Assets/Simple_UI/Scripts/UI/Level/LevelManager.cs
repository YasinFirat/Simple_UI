using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yasinfirat;


public class LevelManager : MonoBehaviour
{
    private DataManager dataManager;
    private GridControl gridControl;
    public List<GridItem> levelItem;
    private int totalLevel;
    public Files data;
    
    private void Awake()
    {
        dataManager = FindObjectOfType<DataManager>();
        gridControl = transform.GetComponentInChildren<GridControl>();
        
        totalLevel = dataManager.GetDataClass(data).ReadAllData().Count;
        
        gridControl.CreateGridMember(totalLevel);
        
        for (int i = 0; i < totalLevel; i++)
        {
            levelItem.Add(gridControl.gridMember.GetComponent<GridItem>(i));
        }
      
    }
    private void Start()
    {
        CheckGridMembers();
    }
    private void OnEnable()
    {
        CheckGridMembers();
    }
    public void CheckGridMembers()
    {
        //level yerleştirmesi yapılacak yapılacak.
        for (int i = 0; i < totalLevel-1; i++)
        {
            levelItem[i].SetInformations(dataManager,i+1);
        }
    }
}
