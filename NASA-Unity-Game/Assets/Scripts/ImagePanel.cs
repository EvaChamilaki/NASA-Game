using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImagePanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject imageToShow;
    private GameObject mainCamera;

    void Start()
    {
        imageToShow.SetActive(false); 
        mainCamera = GameObject.FindWithTag("MainCamera");  
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!mainCamera.GetComponent<MainCamera>().GetInteractionFlag())
        {
           imageToShow.SetActive(true); 
        }
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imageToShow.SetActive(false);  // Hide the image
    }


}
