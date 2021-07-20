using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using yasinfirat;

public class LevelItem : GridItem
{
    private LevelData levelData;
    public StarController starController;
    public LockController lockController ;
    public Text levelIdText;
    public override void SetInformations(DataManager data, int id)
    {
       
       // levelData = data.GetLevel();
       
        bool isPassed = levelData.GetPassed(id);
        if (!isPassed)
            return;

        lockController.SetImageVisible(isPassed);
       
        levelIdText.text = id.ToString();
        starController.CheckStars(levelData.GetStar(id));
    }

}
