using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CropInfoPanel : MonoBehaviour
{
    [TextArea(3, 10)] 
    public TextMeshProUGUI cropInfo;
    public RectTransform infoPanel;

    public static Action<string, Vector2> OnMouseHover; //string: the text we want to display, Vector2: the mouse position
    public static Action OnMouseExit;

    private GameObject mainCamera;

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
        mainCamera = GameObject.FindWithTag("MainCamera");

        HideInfo();
    }

    private void ShowInfo(string info, Vector2 mousePos)
    {
        cropInfo.text = info;

        infoPanel.sizeDelta = new Vector2(cropInfo.preferredWidth >400 ? 400 : cropInfo.preferredWidth, cropInfo.preferredHeight > 200 ? 200 :cropInfo.preferredHeight);

        if (!mainCamera.GetComponent<MainCamera>().GetInteractionFlag())
        {
            infoPanel.gameObject.SetActive(true);
            infoPanel.transform.position = new Vector2(mousePos.x, mousePos.y + infoPanel.sizeDelta.y * 0.5f);
        }
        else
            HideInfo();
    }

    public void HideInfo()
    {
        cropInfo.text = default;
        infoPanel.gameObject.SetActive(false);
    }
}
