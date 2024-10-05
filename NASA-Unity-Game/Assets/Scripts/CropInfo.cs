using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class CropInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string cropInfo;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowMessage();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CropInfoPanel.OnMouseExit();
    }

    private void ShowMessage()
    {
        CropInfoPanel.OnMouseHover(cropInfo, Input.mousePosition);

    }
}
