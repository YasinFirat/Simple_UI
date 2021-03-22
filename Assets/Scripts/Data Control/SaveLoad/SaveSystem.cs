﻿using System.Collections;
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
        public bool firstCreate;
        public  void CheckFile(string file)
        {
            if (!CreatedBeforeFile(file)) //eğer bu dosya yoksa 
            {
                File.Create(SAVE_FOLDER+file);//bu dosyayı kur
                firstCreate = true;
                Debug.Log("Level Dosyası Oluşturuldu");
            }
        }
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

        public bool CreatedBeforeFile(string file)
        {
            return File.Exists(SAVE_FOLDER + file);
        }
    }
}

