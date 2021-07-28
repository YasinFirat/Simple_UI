using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bir cüzdan datası (gold,money olarakta kullanılabilir.)
/// </summary>
[CreateAssetMenu(fileName = "WalletDataController", menuName = "Data/Wallet/Create a WalletController", order = 0)]
public class WalletDataController : DataScriptable
{
   private WalletData walletData;
   public List<WalletTypes> walletTypes;

    public WalletData getData
    {
        get
        {
            return walletData;
        }
        private set { }
    }
    public override void CheckOnLoad()
    {
       
        length = walletTypes.Count;
        walletData.ChechDataOnLoad(this);
        if (!walletData.FirstCreate())
        {
            UpdateDatas();
        }

    }
    public WalletDataController UpdateDatas()
    {
        for (int i = 0; i < length; i++)
        {
            walletTypes[i].walletValue = walletData.GetData(i);
        }
        return this;
    }

    public override void CreateData()
    {
       
        walletData = new WalletData(fileName);
    }
    public override int length => base.length;
}
