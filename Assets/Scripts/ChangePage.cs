using System.Collections.Generic;
using UnityEngine;

public class ChangePage : MonoBehaviour
{
    public Dictionary<string,Canvas> ListCanvas = new Dictionary<string,Canvas>();

    private string UIMain = "UIMain";
    private string UIInventory = "UIInventory";
    private string UIBase = "UIBase";
    private string UIStatus = "UIStatus";


    public void Start()
    {
        SetCanvas();
        OnPage(UIMain);
    }

    public void SetCanvas()
    {
        ListCanvas.Clear();

        Canvas[] canvases = FindObjectsOfType<Canvas>(true); // true: 비활성화된 것도 포함


        foreach (Canvas canvas in canvases)
        {
            //Debug.Log(canvas.name);
            string canvasName = canvas.gameObject.name;

            if (!ListCanvas.ContainsKey(canvasName))
            {
                ListCanvas.Add(canvasName, canvas);
            }
            else
            {
                Debug.LogWarning($"Duplicate Canvas name detected: {canvasName}");
            }
        }
    }

    public void OnPage(string pageName)
    {
        foreach (KeyValuePair<string, Canvas> kvp in ListCanvas)
        {
            if (kvp.Key == pageName)
            {
                kvp.Value.gameObject.SetActive(true);
            }
            else if (kvp.Key == UIBase)
            {
                kvp.Value.gameObject.SetActive(true);
            }
            else
            {
                kvp.Value.gameObject.SetActive(false);
            }
            
        }
    }
}