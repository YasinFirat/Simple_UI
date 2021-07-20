using Unity;
using UnityEngine;
/// <summary>
/// Shop ile ilgili verilerinizi buraya giriniz.(Veri dışında birşey olmasın)
/// </summary>

[System.Serializable]
public struct ShopValues
{
    /// <summary>
    /// Ürünün resmi
    /// </summary>
    public Sprite image;
    /// <summary>
    /// Ürünün adı
    /// </summary>
    public string name;
    /// <summary>
    /// Ürünün Fiyatı
    /// </summary>
    public float prices;
    /// <summary>
    /// Ürünün Satılıp satılmadığını gösterir.
    /// </summary>
    public bool isSold;
    /// <summary>
    /// Ürün Şu anda seçili mi ? 
    /// </summary>
    public bool isSelected;
}
