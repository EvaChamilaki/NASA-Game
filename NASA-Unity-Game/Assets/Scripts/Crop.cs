using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
