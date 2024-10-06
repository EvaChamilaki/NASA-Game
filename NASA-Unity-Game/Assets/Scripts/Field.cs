#define DEBUG_LOG

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [Header("Indices and such")]
    public int fieldIndex = -1;

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
    public float organicHorizonThick = 0.0f;  // const
    // Toxic (magic removal)
    public float lead = 0.0f;
    public float arsenic = 0.0f;
    public float cadmium = 0.0f;

    [Header("Tool factors")]
    public float pHBoost = 1.0f;
    public float nitrogenBoost = 5.0f;  
    public float potassiumBoost = 5.0f; 
    public float phosphorusBoost = 5.0f;
    public float zincBoost = 5.0f;      
    public float sulfurBoost = 5.0f;    
    public float manganeseBoost = 5.0f; 
    public float boronBoost = 5.0f;     
    public float ironBoost = 5.0f;      
    public float leadBoost = 5.0f;
    public float arsenicBoost = 5.0f;
    public float cadmiumBoost = 5.0f;

    [Header("El Overlay")]
    public GameObject overlay;

    [Header("Do not fill!")]
    public bool selected = false;

    private short discoveries = 0;
    private GameObject plantedCrop = null;
    private bool correntPlanting = false;

    private float pHInitial = 5.0f;
    private Drainage drainageInitial = Drainage.CLAY_SOIL;
    private float nitrogenInitial = 0.0f;
    private float potassiumInitial = 0.0f;
    private float phosphorusInitial = 0.0f;
    private float zincInitial = 0.0f;     
    private float sulfurInitial = 0.0f;   
    private float manganeseInitial = 0.0f;
    private float boronInitial = 0.0f;    
    private float ironInitial = 0.0f;     
    private float organicHorizonThickInitial = 0.0f;
    private float leadInitial = 0.0f;
    private float arsenicInitial = 0.0f;
    private float cadmiumInitial = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (fieldIndex == -1)
            Debug.LogError("ERROR::field index not set!");

        pHInitial = pH;
        drainageInitial = drainage;
        nitrogenInitial = nitrogen;
        potassiumInitial = potassium;
        phosphorusInitial = phosphorus;
        zincInitial = zinc;
        sulfurInitial = sulfur;
        manganeseInitial = manganese;
        boronInitial = boron;
        ironInitial = iron;
        organicHorizonThickInitial = organicHorizonThick;
        leadInitial = lead;
        arsenicInitial = arsenic;
        cadmiumInitial = cadmium;

        if (overlay == null)
            Debug.LogError("ERROR::overlay not set!");

        overlay.SetActive(false);

    //discoveries = (short)(Mathf.Pow(2, 4) - 1);
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlantCrop(GameObject crop)
    {
        // Can't plant another crop
        if (plantedCrop != null)
            return;

        plantedCrop = crop;

        // Compatibility check
        correntPlanting = true;
        if (pH < plantedCrop.GetComponent<Crop>().minpH || pH > plantedCrop.GetComponent<Crop>().maxpH)
        {
            correntPlanting = false;
            #if DEBUG_LOG
                        Debug.Log("Incompatible plant!");
#endif
            return;
        }
        else if (drainage == plantedCrop.GetComponent<Crop>().drainage)
        {
            correntPlanting = false;
#if DEBUG_LOG
            Debug.Log("Incompatible plant!");
#endif
            return;
        }
        else if (nitrogen < plantedCrop.GetComponent<Crop>().minNitrogen || nitrogen > plantedCrop.GetComponent<Crop>().maxNitrogen)
        {
            correntPlanting = false;
#if DEBUG_LOG
            Debug.Log("Incompatible plant!");
#endif
            return;
        }
        else if (potassium < plantedCrop.GetComponent<Crop>().minPotassium || potassium > plantedCrop.GetComponent<Crop>().maxPotassium)
        {
            correntPlanting = false;
#if DEBUG_LOG
            Debug.Log("Incompatible plant!");
#endif
            return;
        }
        else if (phosphorus < plantedCrop.GetComponent<Crop>().minPhosphorus || phosphorus > plantedCrop.GetComponent<Crop>().maxPhosphorus)
        {
            correntPlanting = false;
#if DEBUG_LOG
            Debug.Log("Incompatible plant!");
#endif
            return;
        }
        else if (zinc < plantedCrop.GetComponent<Crop>().minZinc || phosphorus > plantedCrop.GetComponent<Crop>().maxZinc)
        {
            correntPlanting = false;
#if DEBUG_LOG
            Debug.Log("Incompatible plant!");
#endif
            return;
        }
        else if (sulfur < plantedCrop.GetComponent<Crop>().minSulfur || sulfur > plantedCrop.GetComponent<Crop>().maxSulfur)
        {
            correntPlanting = false;
#if DEBUG_LOG
            Debug.Log("Incompatible plant!");
#endif
            return;
        }
        else if (manganese < plantedCrop.GetComponent<Crop>().minManganese || manganese > plantedCrop.GetComponent<Crop>().maxManganese)
        {
            correntPlanting = false;
#if DEBUG_LOG
            Debug.Log("Incompatible plant!");
#endif
            return;
        }
        else if (boron < plantedCrop.GetComponent<Crop>().minBoron || boron > plantedCrop.GetComponent<Crop>().maxBoron)
        {
            correntPlanting = false;
#if DEBUG_LOG
            Debug.Log("Incompatible plant!");
#endif
            return;
        }
        else if (iron < plantedCrop.GetComponent<Crop>().minIron || iron > plantedCrop.GetComponent<Crop>().maxIron)
        {
            correntPlanting = false;
#if DEBUG_LOG
            Debug.Log("Incompatible plant!");
#endif
            return;
        }
        else if (organicHorizonThick < plantedCrop.GetComponent<Crop>().minOrganicHorizonThick || organicHorizonThick > plantedCrop.GetComponent<Crop>().maxOrganicHorizonThick)
        {
            correntPlanting = false;
#if DEBUG_LOG
            Debug.Log("Incompatible plant!");
#endif
            return;
        }

#if DEBUG_LOG
            Debug.Log("Compatible plant!");
#endif
    }

    public void ResetField()
    {
        plantedCrop = null;
        correntPlanting = false;

        pH = pHInitial;
        drainage = drainageInitial;
        nitrogen = nitrogenInitial;
        potassium = potassiumInitial;
        phosphorus = phosphorusInitial;
        zinc = zincInitial;
        sulfur = sulfurInitial;
        manganese = manganeseInitial;
        boron = boronInitial;
        iron = ironInitial;
        organicHorizonThick = organicHorizonThickInitial;
        lead = leadInitial;
        arsenic = arsenicInitial;
        cadmium = cadmiumInitial;
    }

    public void Select()
    {
        selected = true;
        overlay.SetActive(true);
    }

    public void Deselect()
    {
        selected = false;
        overlay.SetActive(false);
    }

    public short ReadDiscovery(short bit_index)
    {
        return ReadFromBits(discoveries, bit_index);
    }

    public void WriteDiscovery(short bit_index)
    {
        discoveries = WriteIntoBits(discoveries, bit_index, 1);
    }

    public void UseTool(int toolIndex)
    {
        switch (toolIndex)
        {
            case 0:
                potassium += potassiumBoost;
                phosphorus += phosphorusBoost;
                break;

            case 1:
                nitrogen += nitrogenBoost;
                break;

            case 2:
                zinc += zincBoost;
                break;

            case 3:
                sulfur += sulfurBoost;
                break;

            case 4:
                manganese += manganeseBoost;
                break;

            case 5:
                boron += boronBoost;
                break;

            case 6:
                iron += ironBoost;
                break;
            
            case 7:
                if (drainage == Drainage.CLAY_SOIL)
                    drainage = Drainage.WELL_DRAINED;
                else if (drainage == Drainage.WELL_DRAINED)
                    drainage = Drainage.SANDY_SOIL;
                else if (drainage == Drainage.SANDY_SOIL)
                    drainage = Drainage.SILT_SOIL;
                else if (drainage == Drainage.SILT_SOIL)
                    drainage = Drainage.CLAY_SOIL;
                break;

            case 8:
                if (drainage == Drainage.CLAY_SOIL)
                    drainage = Drainage.SILT_SOIL;
                else if (drainage == Drainage.SILT_SOIL)
                    drainage = Drainage.SANDY_SOIL;
                else if (drainage == Drainage.SANDY_SOIL)
                    drainage = Drainage.WELL_DRAINED;
                else if (drainage == Drainage.WELL_DRAINED)
                    drainage = Drainage.CLAY_SOIL;
                break;

            case 9:
                pH = Math.Min(pH + pHBoost, 14);    // pH can be greater than 14, but doesn't matter in our usecase. Don't shoot me NASA!
                break;

            case 10:
                pH = Math.Max(pH - pHBoost, 0);     // pH can be less than 0, but doesn't matter in our usecase. Don't shoot me NASA!
                break;

            default:
                break;
        }
    }    

    /// <summary>
    /// Bit magic
    /// </summary>
    /// <param name="a">: the short to manipulate</param>
    /// <param name="bit_index">: the index of the bit</param>
    /// <param name="b">: the bit value to write</param>
    /// <returns>: the updated short</returns>
    short WriteIntoBits(short a, short bit_index, int b)
    {
        //if (b != 0 && b != 1 && bit_index >= sizeof(short) * 8)
        //    return a;

        short mask = 0;
        mask = (short)(~(1 << bit_index));

        a = (short)((a & mask) | b << bit_index);

        return a;
    }

    /// <summary>
    /// More bit magic
    /// </summary>
    /// <param name="source">: the source short</param>
    /// <param name="bit_index">: the index of the bit</param>
    /// <returns>: the read bit</returns>
    short ReadFromBits(short source, short bit_index)
    {
        short mask = (short)(1 << bit_index);
        return (short)((source & mask) >> bit_index);
    }
}
