using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockController : MonoBehaviour
{
    public Image lockImage;

   
    public LockController SetImageVisible(bool isEnabled)
    {
       lockImage.enabled = !isEnabled;
        return this;
    }
}
