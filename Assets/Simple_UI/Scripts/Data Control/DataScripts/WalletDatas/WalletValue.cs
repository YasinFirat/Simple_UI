using System.Collections;
using UnityEngine;

/// <summary>
/// Cüzdan görevi görür.
/// </summary>
[System.Serializable]
public struct WalletValue
{
    [Tooltip("Id numarası")]
    public int id;
    public string name;
    [Tooltip("Miktar")]
    public float amount;
   
}

