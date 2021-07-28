using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data scriptable olarak kontrol edilir..
/// </summary>
/// <typeparam name="T1">Mümkünse FileDataControl'den türeyen bir sınıf ekleyin</typeparam>
/// <typeparam name="T2">Data değişkenlerini tutan sınıf</typeparam>

public class DataScriptable : ScriptableObject
{
    protected int _length;
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
    public virtual void CheckOnLoad()
    {
#if UNITY_EDITOR
        Debug.Log("Datalar önceden oluşturuldu mu diye kontrol ediliyor.");
#endif
    }
    /// <summary>
    /// data oluşturur.
    /// </summary>
    public virtual void CreateData()
    {
#if UNITY_EDITOR
        Debug.Log("Data oluşturuldu");
#endif
    }

    public  virtual int length
    {
        get
        {
            return _length;
        }
        set { _length = value; }
    }
}
