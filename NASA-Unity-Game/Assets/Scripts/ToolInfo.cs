using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ToolInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea(3, 10)]
    public string toolInfo;

    private float time = 0.3f;

    public TextMeshProUGUI toolInfoTextComponent;  
    public Image toolInfoImage; 
    public Sprite toolSprite;

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartTime());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        CropInfoPanel.OnMouseExit();
        HideElements();
    }

    private void ShowMessage()
    {
        CropInfoPanel.OnMouseHover(gameObject, toolInfo, Input.mousePosition);
        toolInfoImage.sprite = toolSprite;

        toolInfoImage.gameObject.SetActive(true);
        toolInfoTextComponent.gameObject.SetActive(true);

    }

    private IEnumerator StartTime()
    {
        yield return new WaitForSeconds(time);

        ShowMessage();
    }

      private void HideElements()
    {
        toolInfoImage.gameObject.SetActive(false);
        toolInfoTextComponent.gameObject.SetActive(false);
    }
}
