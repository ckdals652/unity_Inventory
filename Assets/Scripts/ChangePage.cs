using System.Collections.Generic;
using UnityEngine;

public class ChangePage : MonoBehaviour
{
    public Dictionary<string,Canvas> dictionaryCanvas = new Dictionary<string,Canvas>();

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
        dictionaryCanvas.Clear();

        Canvas[] canvases = FindObjectsOfType<Canvas>(true); // true: 비활성화된 것도 포함


        foreach (Canvas canvas in canvases)
        {
            //Debug.Log(canvas.name);
            string canvasName = canvas.gameObject.name;

            //딕셔너리 이름 키에 같은 이름이 없을 때 추가
            if (!dictionaryCanvas.ContainsKey(canvasName))
            {
                dictionaryCanvas.Add(canvasName, canvas);
            }
            else
            {
                Debug.LogWarning($"Duplicate Canvas name detected: {canvasName}");
            }
        }
    }

    public void OnPage(string pageName)
    {
        // foreach (KeyValuePair<string, Canvas> kvp in dictionaryCanvas)
        // {
        //     if (kvp.Key == pageName)
        //     {
        //         kvp.Value.gameObject.SetActive(true);
        //     }
        //     // else if (kvp.Key == UIBase)
        //     // {
        //     //     kvp.Value.gameObject.SetActive(true);
        //     // }
        //     else
        //     {
        //         kvp.Value.gameObject.SetActive(false);
        //     }
        // }
        //
        // dictionaryCanvas[UIBase].gameObject.SetActive(true);
        
        foreach (var kvp in dictionaryCanvas)
        {
            bool isActive = (kvp.Key == pageName || kvp.Key == UIBase);
            kvp.Value.gameObject.SetActive(isActive);
        }
    }
}