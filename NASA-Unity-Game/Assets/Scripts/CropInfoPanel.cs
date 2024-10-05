using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CropInfoPanel : MonoBehaviour
{
    public TMP_Text cropInfo;
    public RectTransform infoPanel;

    public static Action<string, Vector2> OnMouseHover; //string: the text we want to display, Vector2: the mouse position
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

    private void ShowInfo(string info, Vector2 mousePos)
    {
        cropInfo.text = info;
        infoPanel.sizeDelta = new Vector2(cropInfo.preferredWidth, cropInfo.preferredHeight);

        infoPanel.gameObject.SetActive(true);
        infoPanel.transform.position = new Vector2(mousePos.x + infoPanel.sizeDelta.x * 2, mousePos.y);
    }

    private void HideInfo()
    {
        cropInfo.text = default;
        infoPanel.gameObject.SetActive(false);
    }
}
