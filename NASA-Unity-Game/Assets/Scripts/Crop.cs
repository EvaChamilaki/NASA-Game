using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [Header("Stuff")]
    public int cropIndex = -1;

    [Header("Statistics")]
    public float minpH = 5.0f;
    public float maxpH = 10.0f;
    public Drainage drainage = Drainage.CLAY_SOIL;
    // All are kg per hectar
    public float minNitrogen = 0.0f;
    public float maxNitrogen = 0.0f;
    public float minPotassium = 0.0f;
    public float maxPotassium = 0.0f;
    public float minPhosphorus = 0.0f;
    public float maxPhosphorus = 0.0f;
    // All are mg per kg
    public float minZinc = 0.0f;
    public float maxZinc = 0.0f;
    public float minSulfur = 0.0f;
    public float maxSulfur = 0.0f;
    public float minManganese = 0.0f;
    public float maxManganese = 0.0f;
    public float minBoron = 0.0f;
    public float maxBoron = 0.0f;
    public float minIron = 0.0f;
    public float maxIron = 0.0f;
    // cm
    public float minOrganicHorizonThick = 0.0f;  // const
    public float maxOrganicHorizonThick = 0.0f;  // const

    private Vector3 initPos;
    private bool moving = false;
    private GameObject mainCamera;

    public void Clicked()
    {
        if (!mainCamera.GetComponent<MainCamera>().FieldIsSelected())
            return;

        mainCamera.GetComponent<MainCamera>().SetInteractionFlag(true);
        moving = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (cropIndex == -1)
            Debug.LogError("ERROR::crop index not set!");

        initPos = transform.position;
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position = Input.mousePosition;

            // Raycasting section
            RaycastHit hit;
            int layerMask = 1 << 8;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                if (hit.transform.gameObject.CompareTag("Field") && Input.GetMouseButtonDown(0) && hit.transform.gameObject == mainCamera.GetComponent<MainCamera>().GetSelectedField())
                {
                    PlantCrop();
                }
            }
        }
        else
            transform.position = initPos;

        if (moving && Input.GetMouseButtonDown(0))
        {
            transform.position = initPos;
            moving = false;
            mainCamera.GetComponent<MainCamera>().SetInteractionFlag(false);
        }

        if (moving)
            GameObject.FindWithTag("Canvas").GetComponent<CropInfoPanel>().HideInfo();
    }

    void PlantCrop()
    {
        mainCamera.GetComponent<MainCamera>().PlantCrop(gameObject);
        mainCamera.GetComponent<MainCamera>().SetInteractionFlag(false);
        transform.position = initPos;
        moving = false;
    }
}
