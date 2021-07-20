using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace yasinfirat 
{/// <summary>
///  Tüm Data script'leri buradan referans alır.
/// </summary>
    public class SaveSystem : IOnload
    {
        /// <summary>
        /// Dosyaların bulunacağı yol
        /// </summary>
        public readonly string SAVE_FOLDER = Application.persistentDataPath + "/Resources/Saves/";
        /// <summary>
        /// Bir defa dosya kurulduğunda true değerini dönderir
        /// </summary>
        protected bool firstCreate;
        /// <summary>
        /// Hızlı bir şekilde dosya oluşturur.Eğer daha önceden oluşturduysa görmezden gelecektir.
        /// </summary>
        /// <param name="file">Dosya ismini belirleyin.</param>
        public  void CheckFile(string file)
        {
            if (!File.Exists(SAVE_FOLDER + file)) //eğer bu dosya yoksa 
            {
                File.Create(SAVE_FOLDER+file);//bu dosyayı kur
                firstCreate = true;
#if UNITY_EDITOR
                Debug.Log(file + "Dosyası Oluşturuldu");
#endif

            }
        }
        /// <summary>
        /// Klasör oluşturur. 
        /// </summary>
        /// <param name="path">Klasör</param>
        public void CheckFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
#if UNITY_EDITOR
                Debug.Log("Created new folder! Folder name is " + path);
#endif

            }
        }
       
        public bool FirstCreate()
        {
            return firstCreate;
        }
    }
}

