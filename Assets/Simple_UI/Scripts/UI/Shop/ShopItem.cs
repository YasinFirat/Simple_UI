using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : GridItem
{
    private ItemContoller itemContoller;
    private SellProduct sellProduct;

    public int id;
    private ShopValues shopValues;
    public Image image;
    public Image lockImage;
    public Image selectImage;
   
    public Text nameOfProduct;
    public Text prices;
    public bool isSold;
    public bool isSelected;
    
    public override void SetInformations(ItemContoller itemContoller, int id)
    {
        this.id = id;
        sellProduct = new SellProduct(id);
        this.itemContoller = itemContoller;
        shopValues = DataManager.Instance.shopDataController.shopProducts[id].shopValues;
      
        image.sprite = shopValues.image;
        nameOfProduct.text = shopValues.name;
        prices.text = shopValues.prices.ToString();
        isSold = shopValues.isSold;
        isSelected = shopValues.isSelected;
        lockImage.enabled = !isSold;
        selectImage.enabled = isSelected;
    }
    /// <summary>
    /// Tıklanma esnasında aktif objeyi seçili hale getirir.
    /// </summary>
    public void selectThis()
    {//seçili obje'nin id numarası alınır
        int changeId = DataManager.Instance.shopDataController.getData.findSelectedId; 
        //seçim kaldırılır ve yeni seçim eklenir.
        DataManager.Instance.shopDataController.getData.SetSelected(changeId,false).SetSelected(id,true); //önceki seçili obje değiştirildi.
        //ürünlerin hepsi güncellenir
        DataManager.Instance.shopDataController.UpdateDatas();
        itemContoller.CheckGridMembers();
    }

    public void SellThis()
    {
        if (sellProduct.SellThis())
        {
            lockImage.enabled = !isSold;
            DataManager.Instance.shopDataController.UpdateDatas();
            itemContoller.CheckGridMembers();
        }
       
    }
}
