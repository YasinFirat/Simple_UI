using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GridMember 
{
    public GameObject obj;
    public List<GameObject> members;
    public int total;

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
    public T GetComponent<T>(int index)
    {
        return members[index].GetComponent<T>();
    }
    public int GetTotal()
    {
        return total;
    }
    public GridMember SetTotal(int total)
    {
        this.total = total;
        return this; 
    }
}
public class GridControl : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    public CanvasScaler canvasScaler;
    
    public GridMember gridMember;

    private void Start()
    {
      
       
    }
    private void CalculateGridHeight()
    {
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

    public GridControl CreateGridMember(int total)
    {
        gridMember.SetTotal(total).CreateGridMember(transform);
        CalculateGridHeight();
        return this;
    }
}
