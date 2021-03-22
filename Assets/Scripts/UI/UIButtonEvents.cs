using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonEvents : MonoBehaviour
{
    [Tooltip("When the game opens, drag the first page to opened here.")]
    public Canvas canvasPage;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Canvas aktif değilse aktif edilir,aktif ise pasif edilir.
    /// </summary>
    /// <param name="canvas"></param>
    public void EnableAndDisable(Canvas canvas)
    {
        canvas.enabled = !canvas.isActiveAndEnabled;
    }
    public void EnableAndDisable(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    /// <summary>
    /// Activates a new canvas and passes(nonActive) the previous canvas
    /// </summary>
    /// <param name="canvas"></param>
    public void OpenNewPage(Canvas canvas)
    {
        if(canvas!=null)
            canvasPage.enabled = false;

        canvasPage = canvas;
        canvasPage.enabled = true;
    }
}
