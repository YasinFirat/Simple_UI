using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yasinfirat;

public class WalletData :FileDataControl
{
    public WalletValue walletValues;
    private string FILENAME = "";

    public WalletData(string fileName) : base(fileName)
    {
        if (FILENAME.Length > 0)
            return;
        FILENAME = fileName;
    }
    
    public WalletData ChechDataOnLoad(WalletDataController walletDataController)
    {
        //ilk defa çalıştırılırsa aşağıdaki if bloğu çalışır.
        if (firstCreate)
        {
            data = new List<string>();


            for (int i = 0; i < walletDataController.length; i++)
            {
                walletDataController.walletTypes[i].walletValue.id = i;
                AddData(walletDataController.walletTypes[i].walletValue);
            }
            SaveData();

        }
        return this;
    }

    #region Gets
    public float GetAmount(int index)
    {
        walletValues = WriteData<WalletValue>(index); //data sınıfa aktarılır.
        return walletValues.amount; //data döndürülür.
    }
    public float GetAmount(string name)
    {
        int index = findWithName(name);
        if (index == -1)
        {
            return 0;
        }
        walletValues = WriteData<WalletValue>(index); //data sınıfa aktarılır.
        return walletValues.amount; //data döndürülür.
    }
    public int GetID(int index)
    {
        walletValues = WriteData<WalletValue>(index); //data sınıfa aktarılır.
        return walletValues.id; //data döndürülür.
    }public int GetID(string name)
    {
        int index = findWithName(name);
        if (index == -1)
        {
            return 0;
        }
        walletValues = WriteData<WalletValue>(index); //data sınıfa aktarılır.
        return walletValues.id; //data döndürülür.
    }
    public string GetName(int index)
    {
        walletValues = WriteData<WalletValue>(index); //data sınıfa aktarılır.
        return walletValues.name; //data döndürülür.
    }
    public WalletValue GetData(int index)
    {
        return WriteData<WalletValue>(index);
    }
    public WalletValue GetData(string name)
    {
        int index = findWithName(name);
        if (index == -1)
        {
            return new WalletValue();
        }
        return WriteData<WalletValue>(index);
    }
    #endregion

    #region Sets

    public WalletData SetAmound(int index, int newValue)
    {
        ReadAllData();

        walletValues = WriteData<WalletValue>(index);
        walletValues.amount = newValue;

        ChangeData(walletValues, index);
        SaveData();
        return this;
    }
    public WalletData SetAmound(string name, int newValue)
    {
        int index = findWithName(name);
        if (index == -1)
        {
            return this;
        }
        ReadAllData();

        walletValues = WriteData<WalletValue>(index);
        walletValues.amount = newValue;

        ChangeData(walletValues, index);
        SaveData();
        return this;
    }

    #endregion

    #region Spends
    /// <summary>
    /// Harcama yapılır
    /// </summary>
    /// <param name="index">Cüzdan </param>
    /// <param name="spendAmound"></param>
    /// <returns></returns>
    public WalletData Spend(int index, float spendAmound)
    {

        ReadAllData();

        walletValues = WriteData<WalletValue>(index);
        walletValues.amount -= spendAmound;
        if (walletValues.amount < 0)
        {
            walletValues.amount = 0;
        }

        ChangeData(walletValues, index);
        SaveData();
        return this;
    } 
    public WalletData Spend(string name, float spendAmound)
    {
        int index = findWithName(name);
        if (index == -1)
        {
            return this;
        }
        ReadAllData();

        walletValues = WriteData<WalletValue>(index);
        walletValues.amount -= spendAmound;
        if (walletValues.amount < 0)
        {
            walletValues.amount = 0;
        }

        ChangeData(walletValues, index);
        SaveData();
        return this;
    }
    public WalletData Earn(int index, int earnAmound)
    {
        ReadAllData();

        walletValues = WriteData<WalletValue>(index);
        walletValues.amount += earnAmound;

        ChangeData(walletValues, index);
        SaveData();
        return this;
    }public WalletData Earn(string name, int earnAmound)
    {
        int index = findWithName(name);
        if (index == -1)
        {
            return this;
        }
        ReadAllData();

        walletValues = WriteData<WalletValue>(index);
        walletValues.amount += earnAmound;

        ChangeData(walletValues, index);
        SaveData();
        return this;
    }

    #endregion

    private int findWithName(string name)
    {
        int index = -1;
        ReadAllData();
        for (int i = 0; i<data.Count; i++)
        {
            if (GetName(i).Equals(name))
            {
                index = i; break;
            }
               

        }
       
        return index;
    }
}
