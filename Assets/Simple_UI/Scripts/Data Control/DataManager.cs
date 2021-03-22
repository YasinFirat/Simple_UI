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
    public GameObject openGame;
    public LevelData levelData;
    FileDataControl fileDataControl;
    
    // Start is called before the first frame update
    void Awake()
    {
        fileDataControl = new FileDataControl();
        levelData = new LevelData("levels.txt");
    }
    private void Start()
    {
        levelData.CheckDataOnLoad(100);
        openGame.SetActive(true);
        DontDestroyOnLoad(gameObject);
    }
    public FileDataControl GetDataClass(Files files)
    {
        switch (files)
        {
            case Files.LevelData:
                fileDataControl = levelData;
                break;
            case Files.ShopData:
                break;
            case Files.ScoreData:
                break;
            default:
                break;
        }
        return fileDataControl;
    }

    public LevelData GetLevel()
    {
        return levelData;
    }
    
    
}
