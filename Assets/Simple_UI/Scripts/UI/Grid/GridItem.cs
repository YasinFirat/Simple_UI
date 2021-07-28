using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yasinfirat;
public abstract class GridItem : MonoBehaviour
{
    /// <summary>
    /// Data'dan alınan verilerin aktarma işletimi yapar
    /// </summary>
    /// <param name="data">Data</param>
    /// <param name="id">Bilgisi alınacak data'nın id numarası</param>
    public abstract void SetInformations(ItemContoller ıtemContoller,int id);
}
