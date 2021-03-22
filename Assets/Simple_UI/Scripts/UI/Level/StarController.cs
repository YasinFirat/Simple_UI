using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour
{
    public Color32 enableColor;
    public Color32 disableColor;
    public List<Image> stars;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            stars.Add(transform.GetChild(i).gameObject.GetComponent<Image>());
        }
    }

    public StarController CheckStars(int startAmount)
    {
        for (int i = 0; i < stars.Count; i++)
        {
            Debug.Log(startAmount + " , " + transform.name);
            stars[i].color = disableColor;
        }

        for (int i = 0; i < startAmount; i++)
        {
           
            stars[i].color = enableColor;
        }
        return this;
    }
}
