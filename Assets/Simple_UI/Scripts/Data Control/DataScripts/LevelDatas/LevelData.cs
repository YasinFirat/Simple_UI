using System.Collections.Generic;
using System.Threading;
using yasinfirat;


public class LevelData : FileDataControl
{
    public string FILENAME = "";


    #region values
    DataValues dataValues; //data sınıfı
    #endregion
    public LevelData()
    {
        fileName = FILENAME;
    }
    public LevelData(string fileName) : base(fileName)
    {
        
        if (FILENAME.Length > 0)
            return;
        FILENAME = fileName;
    }
    #region Interfaces
    public void CheckDataOnLoad(DataScriptable levelDataScriptable)
    {
        if (firstCreate)
        {
            data = new List<string>();
            for (int i = 0; i < levelDataScriptable.defaultValueses.Count; i++)
            {
                AddData(levelDataScriptable.defaultValueses[i]);
            }
            SaveData();
           // CopyDataValues(1, 0);
        }
    }
    //public void CheckDataOnLoad(int index)
    //{

    //    if (firstCreate)
    //    {
    //        data = new List<string>();

    //        for (int i = 0; i < index; i++)
    //        {
    //            if (i == 1)
    //            {
    //                dataValues.Level = i;
    //                dataValues.starCount = 0;
    //                dataValues.passed = true;

    //                AddData(dataValues);

    //            }
    //            else
    //            {
    //                dataValues.Level = i;
    //                dataValues.starCount = 0;
    //                dataValues.passed = false;
    //                AddData(dataValues);
    //            }

    //        }
               
    //        SaveData();
    //        CopyDataValues(1, 0);
    //    }

    //}
    #endregion
    #region Gets
    public int GetStar(int index)
    {
       
        dataValues = WriteData<DataValues>(index); //data sınıfa aktarılır.
        return dataValues.starCount; //data döndürülür.
    }
    public bool GetPassed(int index)
    {
       
        dataValues = WriteData<DataValues>(index);
        return dataValues.passed;
    }
    #endregion
    #region Sets
    public void SetStar(int index, int newValue)
    {
        ReadAllData();
        dataValues = WriteData<DataValues>(index);
        dataValues.starCount = newValue;
        ChangeData(dataValues, index);

        SaveData();
    }

    public void SetPassed(int index, bool newValue)
    {
        ReadAllData();
        dataValues = WriteData<DataValues>(index);
        dataValues.passed = newValue;
        ChangeData(dataValues, index);
        SaveData();
    }
    #endregion
}



