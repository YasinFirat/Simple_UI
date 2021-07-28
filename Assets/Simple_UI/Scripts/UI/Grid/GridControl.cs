using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Grid üyelerini oluşturur ve kolay ulaşılması için bunları listede tutar.
/// </summary>
[System.Serializable]
public class GridMember 
{
    [Tooltip("Kopyasının oluşmasını istediğiniz objeyi sürükleyin.")]
    public GameObject obj;
    [Tooltip("Tüm grid listesi ve burada istediğiniz grid'e gameObject olarak ulaşabilirsiniz")]
    public List<GameObject> members;
    public int total;
    /// <summary>
    /// Grid oluşturur.
    /// </summary>
    /// <param name="parent">İstenilen grid'in parent objesi</param>
    public void CreateGridMember(Transform parent)
    {
        members.Add(obj);
        for (int i = 1; i < total; i++)
        {
           members.Add( MonoBehaviour.Instantiate(obj, parent));
        }
    }
    public GameObject GetMember(int index)
    {
        return members[index];
    }
    /// <summary>
    /// index numarasına göre nesne'nin componenti alınır.
    /// (dizi gameObject olduğundan dolayı index numarasına göre component get etmek durumunda kaldım.)
    /// </summary>
    /// <typeparam name="T">Component türü</typeparam>
    /// <param name="index">Grid'in index numarası</param>
    /// <returns></returns>
    public T GetComponent<T>(int index)
    {
        return members[index].GetComponent<T>();
    }
    /// <summary>
    /// Kaç adet grid üyesi olduğunu gösterir.
    /// </summary>
    /// <returns></returns>
    public int GetTotal()
    {
        return total;
    }
    /// <summary>
    /// Oluşturulması istenen grid sayısı girilir
    /// </summary>
    /// <param name="total"></param>
    /// <returns></returns>
    public GridMember SetTotal(int total)
    {
        this.total = total;
        return this; 
    }
}
/// <summary>
/// Grid'lerin hesaplama ve yerleşim işlemini bizzat bu sınıf yapar.
/// </summary>
public class GridControl : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    public CanvasScaler canvasScaler;
    
    public GridMember gridMember;

   /// <summary>
   /// Canvas üzerindeki gridin boyutu hesaplanır ve boyutu oluşturulur.
   /// 
   /// </summary>
    private void CalculateGridHeight()
    {//Metod içindeki aşamalar daha sonra yazılacak.
        RectTransform recTransform;
        float distanceOfRow,heightThisRect;
        int column, row;
        float paddingTotal = gridLayoutGroup.padding.left + gridLayoutGroup.padding.right;
        float SizeSpacingTotal = gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x;


        column = (int)((canvasScaler.referenceResolution.x - paddingTotal)/ SizeSpacingTotal);
        row = 1 + transform.childCount / column;
        
        distanceOfRow = gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y;
        heightThisRect = distanceOfRow * row;
        if (heightThisRect <= 500)
            return;
        Vector2 recScale;
        recTransform = GetComponent<RectTransform>();
        recScale = recTransform.sizeDelta;
        recScale.y = heightThisRect;
        recTransform.sizeDelta = recScale;
    }
    /// <summary>
    /// Grid oluşturulur ve yerleşim hesaplamaları yapılır.
    /// </summary>
    /// <param name="total">Toplam boyutu</param>
    /// <returns></returns>
    public GridControl CreateGridMember(int total)
    {
        gridMember.SetTotal(total).CreateGridMember(transform);
        CalculateGridHeight();
        return this;
    }
}
