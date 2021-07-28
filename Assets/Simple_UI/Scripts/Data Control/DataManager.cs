using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yasinfirat;

/// <summary>
/// Data'ya hızlı bir biçimde erişim sağlanabilir.
/// </summary>
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public ShopDataController shopDataController; 
    public WalletDataController walletDataController;
   
    public GameObject openThisWhenStart;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        
        shopDataController.CreateData();
        walletDataController.CreateData();
    }
    private void Start()
    {
        shopDataController.CheckOnLoad();
        walletDataController.CheckOnLoad();
        
        //   openGame.SetActive(true);
        DontDestroyOnLoad(gameObject);//Sahne geçişlerinde bu objeyi silme
        
    }

   
    

  
    
    
}
