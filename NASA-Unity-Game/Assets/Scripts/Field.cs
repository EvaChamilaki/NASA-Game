using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From lowest water to highest
public enum Drainage
{
    CLAY_SOIL,
    WELL_DRAINED,           // Same as loamy
    SANDY_SOIL,
    SILT_SOIL               // Flooded
};

public class Field : MonoBehaviour
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
    // Toxic (magic removal)
    public float lead = 0.0f;
    public float arsenic = 0.0f;
    public float cadmium = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
