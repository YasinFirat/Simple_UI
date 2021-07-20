using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yasinfirat;

public enum Files
{
    LevelData,
    ShopData,
    ScoreData
}
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public DataScriptable dataScriptable;
    public LevelDataScriptable levelDataScriptable;
    public ShopScriptable shopScriptable;
    public string dataName="Levels";
    public GameObject openGame;
   // LevelData levelData;
    ShopData shopData;
   // FileDataControl fileDataControl;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    
        levelDataScriptable.CreateData();
        shopScriptable.CreateData();
        


    }
    private void Start()
    {
     
        shopScriptable.CheckOnLoad();
        levelDataScriptable.CheckOnLoad();
        
       
        openGame.SetActive(true);
        DontDestroyOnLoad(gameObject);//Sahne geçişlerinde bu objeyi silme
        
    }

   
    public DataScriptable GetDataClass(DataScriptable dataScriptable)
    {

        this.dataScriptable = dataScriptable;
        return dataScriptable;
    }

  
    
    
}
