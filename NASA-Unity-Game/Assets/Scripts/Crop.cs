using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [Header("Statistics")]
    public float pH = 5.0f;             // lime to increase, organic to decrease
    public Drainage drainage = Drainage.CLAY_SOIL;      // tractor to change
    // All are kg per hectar
    public float nitrogen = 0.0f;       // seaweed
    public float potassium = 0.0f;      // manure
    public float phosphorus = 0.0f;     // manure
    // All are mg per kg
    public float zinc = 0.0f;           // compost
    public float sulfur = 0.0f;         // fertilizer
    public float manganese = 0.0f;      // fertilizer
    public float boron = 0.0f;          // fertilizer
    public float iron = 0.0f;           // fertilizer
    // cm
    public float organic_horizon_thick = 0.0f;  // const

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
