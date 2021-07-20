using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data scriptable olarak kontrol edilir..
/// </summary>
/// <typeparam name="T1">Mümkünse FileDataControl'den türeyen bir sınıf ekleyin</typeparam>
/// <typeparam name="T2">Data değişkenlerini tutan sınıf</typeparam>

public class DataScriptable : RootDataScriptable<object, object>
{
    public int length;
    public string fileName;

    /// <summary>
    /// .txt uzantılı olarak dosya adı alınır
    /// </summary>
    public string getFileName
    {
        get
        {
            return fileName + ".txt";
        }

    }

    /// <summary>
    /// Oyun Cihazda ilk defa çalıştırıyorsa default verileri aktarır.
    /// </summary>
    public void CheckOnLoad()
    {

    }
    /// <summary>
    /// data oluşturur.
    /// </summary>
    public void CreateData()
    {

    }
}
