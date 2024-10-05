using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScientificInstrument : MonoBehaviour
{
    public int toolIndex = -1;

    private Vector3 initPos;
    private bool moving = false;
    private GameObject mainCamera;

    public void Clicked()
    {
        moving = true;
    }    

    // Start is called before the first frame update
    void Start()
    {
        if (toolIndex == -1)
            Debug.LogError("ERROR::instrument index not set!");

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

                if (hit.transform.gameObject.CompareTag("Field") && Input.GetMouseButtonDown(0))
                {
                    Measure();
                }
            }
        }
        else
            transform.position = initPos;

        if (moving && Input.GetMouseButtonDown(0))
        {
            transform.position = initPos;
            moving = false;
        }
    }

    void Measure()
    {
        mainCamera.GetComponent<MainCamera>().Discover(toolIndex);
        transform.position = initPos;
        moving = false;
    }
}
