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

    [Header("Do not fill!")]
    public bool selected = false;

    private short discoveries = 0;
    private GameObject plantedCrop = null;
    private bool correntPlanting = false;

    // Start is called before the first frame update
    void Start()
    {
        if (fieldIndex == -1)
            Debug.LogError("ERROR::field index not set!");

        // Calculate puzzle status on solution
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
            return;
        }
        else if (drainage == plantedCrop.GetComponent<Crop>().drainage)
        {
            correntPlanting = false;
            return;
        }
        else if (nitrogen < plantedCrop.GetComponent<Crop>().minNitrogen || nitrogen > plantedCrop.GetComponent<Crop>().maxNitrogen)
        {
            correntPlanting = false;
            return;
        }
        else if (potassium < plantedCrop.GetComponent<Crop>().minPotassium || potassium > plantedCrop.GetComponent<Crop>().maxPotassium)
        {
            correntPlanting = false;
            return;
        }
        else if (phosphorus < plantedCrop.GetComponent<Crop>().minPhosphorus || phosphorus > plantedCrop.GetComponent<Crop>().maxPhosphorus)
        {
            correntPlanting = false;
            return;
        }
        else if (zinc < plantedCrop.GetComponent<Crop>().minZinc || phosphorus > plantedCrop.GetComponent<Crop>().maxZinc)
        {
            correntPlanting = false;
            return;
        }
        else if (sulfur < plantedCrop.GetComponent<Crop>().minSulfur || sulfur > plantedCrop.GetComponent<Crop>().maxSulfur)
        {
            correntPlanting = false;
            return;
        }
        else if (manganese < plantedCrop.GetComponent<Crop>().minManganese || manganese > plantedCrop.GetComponent<Crop>().maxManganese)
        {
            correntPlanting = false;
            return;
        }
        else if (boron < plantedCrop.GetComponent<Crop>().minBoron || boron > plantedCrop.GetComponent<Crop>().maxBoron)
        {
            correntPlanting = false;
            return;
        }
        else if (iron < plantedCrop.GetComponent<Crop>().minIron || iron > plantedCrop.GetComponent<Crop>().maxIron)
        {
            correntPlanting = false;
            return;
        }
        else if (organicHorizonThick < plantedCrop.GetComponent<Crop>().minOrganicHorizonThick || organicHorizonThick > plantedCrop.GetComponent<Crop>().maxOrganicHorizonThick)
        {
            correntPlanting = false;
            return;
        }
    }

    public void ResetField()
    {
        plantedCrop = null;
        correntPlanting = false;
    }

    public void Select()
    {
        selected = true;
    }

    public void Deselect()
    {
        selected = false;
    }

    public short ReadDiscovery(short bit_index)
    {
        return ReadFromBits(discoveries, bit_index);
    }

    public void WriteDiscovery(short bit_index)
    {
        discoveries = WriteIntoBits(discoveries, bit_index, 1);
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
