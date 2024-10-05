using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class CropInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea(3, 10)]
    public string cropInfo;

    private float time = 0.3f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartTime());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        CropInfoPanel.OnMouseExit();
    }

    private void ShowMessage()
    {
        CropInfoPanel.OnMouseHover(cropInfo, Input.mousePosition);

    }

    private IEnumerator StartTime()
    {
        yield return new WaitForSeconds(time);

        ShowMessage();
    }
}
