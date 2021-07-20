using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
namespace yasinfirat
{
    /// <summary>
    /// Dataları; yazma,okuma,güncelleme gibi işlemleri yapar.
    /// </summary>
    public class FileDataControl : SaveSystem
    { /// <summary>
    /// Dosya ismini giriniz.
    /// </summary>
        public string fileName;
        /// <summary>
        /// Dataların tutulacağı dizi
        /// </summary>
        public List<string> data;
        /// <summary>
        /// Dosyanın bulunduğu yol.
        /// </summary>
        public string pathFile { get { return SAVE_FOLDER + fileName; } private set { } }
        /// <summary>
        /// Root Klasörnün olup olmadığını kontrol eder.(data dosyası belirletmeden önce kullanılabilir.)
        /// </summary>
        public FileDataControl()
        {
            CheckFolder(SAVE_FOLDER);
        }
        /// <summary>
        /// Data dosyasının olup olmadığını kontrol eder
        /// </summary>
        /// <param name="fileName"></param>
        public FileDataControl(string fileName)
        {
            this.fileName = fileName;
            CheckFile(fileName);
        }
        /// <summary>
        /// İşlem yaptıktan sonra datayı kaydetmeyi unutmayın
        /// Dont forget save data :)
        /// </summary>
        public FileDataControl SaveData()
        {
            File.WriteAllLines(pathFile, data);
            return this;
        }
        /// <summary>
        /// Read all data(type of json)
        /// </summary>
        /// <param name="file">File path</param>
        /// <returns></returns>
        public List<string> ReadAllData()
        {
            data = new List<string>();
            try
            {
                //All data are read in json format in line order.
                data = (File.ReadAllLines(pathFile)).ToList();

                return data;
            }
            catch (FileNotFoundException)
            {
                Debug.LogErrorFormat("There is no file named " + pathFile);
                return data;
            }
        }
        /// <summary>
        /// Read data by index number(type of json)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string ReadData(int index)
        {
            data = new List<string>();
            try
            {
                //All data are read in json format in line order.
                data = (File.ReadAllLines(pathFile)).ToList();
                return data[index];
                
            }
            catch (FileNotFoundException)
            {
                Debug.LogErrorFormat("There is no file named " + pathFile);
                return "";
            }
        }
        /// <summary>
        /// İstenilen data için kopyala ve yapıştırma işlemi yapılır.
        /// </summary>
        /// <param name="copyindex"> Kopyalanacak datanın index numarası</param>
        /// <param name="pasteIndex">Yapıştırılacak datanın index yolu</param>
        /// <returns></returns>
        public FileDataControl CopyDataValues(int copyindex, int pasteIndex)
        {
            data = ReadAllData();
            data[pasteIndex] = data[copyindex];
            SaveData();
            return this;
        }
        /// <summary>
        /// Data'ya json tipinde veri ekler.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public FileDataControl AddData(object obj)
        {
            data.Add(JsonUtility.ToJson(obj));
            return this;
        }
       /// <summary>
       /// Json tipinde veriyi okur.
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="index"></param>
       /// <returns></returns>
        public  T WriteData<T>(int index)
        {
            return JsonUtility.FromJson<T>(ReadData(index));
        }
        /// <summary>
        /// Veriyi json tipine çevirerek dönüştürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public FileDataControl ChangeData<T>(T obj,int index)
        {
            data[index] = JsonUtility.ToJson(obj);
            return this;
        }

       

        
    }
}