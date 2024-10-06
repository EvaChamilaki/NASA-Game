using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class CropInfoPanel : MonoBehaviour
{
    public TextMeshProUGUI cropInfo;
    public TextMeshProUGUI toolsInfo;
    public RectTransform infoPanel;
    public RectTransform toolInfoPanel;

    public static Action<GameObject, string, Vector2> OnMouseHover; //string: the text we want to display, Vector2: the mouse position
    public static Action OnMouseExit;

    void OnEnable()
    {
        OnMouseHover += ShowInfo;
        OnMouseExit += HideInfo;
    }

    void OnDisable()
    {
        OnMouseHover -= ShowInfo;
        OnMouseExit -= HideInfo;
    }
    // Start is called before the first frame update
    void Start()
    {
        HideInfo();
    }

    private void ShowInfo(GameObject hoveredObject, string info, Vector2 mousePos)
    {
        if(hoveredObject.CompareTag("Crop Information"))
        {
            cropInfo.text = info;
            infoPanel.sizeDelta = new Vector2(cropInfo.preferredWidth > 400 ? 400 : cropInfo.preferredWidth, cropInfo.preferredHeight > 200 ? 200 : cropInfo.preferredHeight);
            infoPanel.gameObject.SetActive(true);
            infoPanel.transform.position = new Vector2(mousePos.x, mousePos.y + infoPanel.sizeDelta.y * 0.5f);
        }

        else if (hoveredObject.CompareTag("Tool Information"))
        {
            toolsInfo.text = info;
            toolInfoPanel.sizeDelta = new Vector2(toolsInfo.preferredWidth>200? 200: toolsInfo.preferredWidth, toolsInfo.preferredHeight > 100 ? 100: toolsInfo.preferredHeight);
            toolInfoPanel.gameObject.SetActive(true);
            toolInfoPanel.transform.position = new Vector2(mousePos.x-toolInfoPanel.sizeDelta.x * 0.6f, mousePos.y+toolInfoPanel.sizeDelta.y*0.1f);
        }
        

        

       
    }

    private void HideInfo()
    {
        cropInfo.text = default;
        toolsInfo.text = default;
        infoPanel.gameObject.SetActive(false);
        toolInfoPanel.gameObject.SetActive(false);
    }
}
