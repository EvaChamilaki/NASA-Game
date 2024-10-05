// MACROS
#define DEBUG_LOG

using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using System;

public class MainCamera : MonoBehaviour
{
    [Header("Initial state")]
    [Tooltip("Camera position")]
    public Vector3 initialPos;
    [Tooltip("Camera rotation")]
    public Vector3 initialRot;

    [Header("Input sensitivities")]
    public float panSensitivity = 1.0f;
    public float zoomSensitivity = 1.0f;

    [Header("Movement constraints")]
    public float panLimitX = 5.0f;
    public float panLimitZ = 5.0f;
    public float zoomLimitLow = 3.0f;
    public float zoomLimitHigh = 10.0f;

    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
        mainCam.transform.position = initialPos;
        mainCam.transform.Rotate(initialRot);
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        // Input handling for panning
        Vector3 newPos = mainCam.transform.position;
        if (Input.GetKeyDown(KeyCode.W))
            newPos = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y,
                Math.Clamp(mainCam.transform.position.z + panSensitivity * dt, -panLimitZ, panLimitZ));
        else if (Input.GetKeyDown(KeyCode.S))
            newPos = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y,
                Math.Clamp(mainCam.transform.position.z - panSensitivity * dt, -panLimitZ, panLimitZ));
        if (Input.GetKeyDown(KeyCode.D))
            newPos = new Vector3(Math.Clamp(mainCam.transform.position.x + panSensitivity * dt,
                -panLimitX, panLimitX), mainCam.transform.position.y, mainCam.transform.position.z);
        else if (Input.GetKeyDown(KeyCode.A))
            newPos = new Vector3(Math.Clamp(mainCam.transform.position.x - panSensitivity * dt, -panLimitX, panLimitX),
                mainCam.transform.position.y, mainCam.transform.position.z);

        // Input handling for zooming
        // TODO: Add wheeeeeeel!
        if (Input.GetKeyDown(KeyCode.E))
            newPos = new Vector3(mainCam.transform.position.x, Math.Clamp(mainCam.transform.position.y - zoomSensitivity * dt, zoomLimitLow, zoomLimitHigh), mainCam.transform.position.z);
        else if (Input.GetKeyDown(KeyCode.Q))
            newPos = new Vector3(mainCam.transform.position.x, Math.Clamp(mainCam.transform.position.y + zoomSensitivity * dt, zoomLimitLow, zoomLimitHigh), mainCam.transform.position.z);

#if DEBUG_LOG
        if (mainCam.transform.position != newPos)
            Debug.Log("New pos: " + newPos);
#endif

        mainCam.transform.position = newPos;
    }
}
