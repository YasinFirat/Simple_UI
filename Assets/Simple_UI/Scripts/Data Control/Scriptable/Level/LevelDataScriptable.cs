using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelData",menuName ="Data/Level",order =1)]
public class LevelDataScriptable : DataScriptable
{
    
    public new void CheckOnLoad()
    {
        ((LevelData)data).CheckDataOnLoad(this);
    }
    public new void CreateData()
    {
        data = new LevelData(getFileName);
    }
  


}
