using System.Collections.Generic;
using System.Threading;
using yasinfirat;

namespace yasinfirat
{
    struct DataValues
    {
        #region dataValues
        public int Level;
        public int starCount;
        public bool passed;
        #endregion
    }
    public class LevelData : FileDataControl, IJsonData
    {
        private static string FILENAME = "";


        #region values
        DataValues dataValues;
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
        public void CheckDataOnLoad(int index)
        {

            if (firstCreate)
            {
                data = new List<string>();

                for (int i = 0; i < index; i++)
                {
                    if (i == 1)
                    {
                        dataValues.Level = i;
                        dataValues.starCount = 0;
                        dataValues.passed = true;

                        AddData(dataValues);

                    }
                    else
                    {
                        dataValues.Level = i;
                        dataValues.starCount = 0;
                        dataValues.passed = false;
                        AddData(dataValues);
                    }

                }
               
                SaveData();
                CopyDataValues(1, 0);
            }

        }
        #endregion
        #region Gets
        public int GetStar(int index)
        {

            dataValues = WriteData<DataValues>(index);
            return dataValues.starCount;
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
}


