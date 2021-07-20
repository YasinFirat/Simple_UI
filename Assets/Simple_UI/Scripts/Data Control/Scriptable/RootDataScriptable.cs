using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootDataScriptable<T1, T2> : ScriptableObject
{

    /// <summary>
    /// Data sınıfı
    /// </summary>
    public T1 data;
    public List<T2> defaultValueses;

    /// <summary>
    /// Data get edilir
    /// </summary>
    public T1 getData
    {
        get
        {
            return data;
        }
    }

   
}
