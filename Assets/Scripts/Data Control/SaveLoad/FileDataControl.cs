using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
namespace yasinfirat
{
    /// <summary>
    /// 
    /// </summary>
    public class FileDataControl : SaveSystem
    {
        public string fileName;
        public List<string> data;
        public string pathOfFile { get { return SAVE_FOLDER + fileName; } }
        public FileDataControl()
        {
            CheckFolder(SAVE_FOLDER);

        }
        
        public FileDataControl(string fileName)
        {
            this.fileName = fileName;
            CheckFile(fileName);
        }
        /// <summary>
        /// Dont forget save data :)
        /// </summary>
        public FileDataControl SaveData()
        {
            File.WriteAllLines(pathOfFile, data);
            return this;
        }
        /// <summary>
        /// Transfer all data
        /// </summary>
        /// <param name="file">File path</param>
        /// <returns></returns>
        public List<string> ReadAllData()
        {
            data = new List<string>();
            try
            {
                //All data are read in json format in line order.
                data = (File.ReadAllLines(pathOfFile)).ToList();

                return data;
            }
            catch (FileNotFoundException)
            {
                Debug.LogErrorFormat("There is no file named " + pathOfFile);
                return data;
            }
        }
        public string ReadData(int index)
        {
            data = new List<string>();
            try
            {
                //All data are read in json format in line order.
                data = (File.ReadAllLines(pathOfFile)).ToList();
                return data[index];
                
            }
            catch (FileNotFoundException)
            {
                Debug.LogErrorFormat("There is no file named " + pathOfFile);
                return "";
            }
        }

        public FileDataControl CopyDataValues(int copyindex, int pasteIndex)
        {
            data = ReadAllData();
            data[pasteIndex] = data[copyindex];
            SaveData();
            return this;
        }
        public FileDataControl AddData(object obj)
        {
            data.Add(JsonUtility.ToJson(obj));
            return this;
        }
        public  T WriteData<T>(int index)
        {
            return JsonUtility.FromJson<T>(ReadData(index));
        }
        public FileDataControl ChangeData<T>(T obj,int index)
        {
            data[index] = JsonUtility.ToJson(obj);
            return this;
        }

       

        
    }
}