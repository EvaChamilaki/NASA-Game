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
    public float rotSensitivity = 50.0f;

    [Header("Movement constraints")]
    public float panLimitX = 5.0f;
    public float panLimitZ = 5.0f;
    public float zoomLimitLow = 3.0f;
    public float zoomLimitHigh = 10.0f;

    [Header("Rotation constraints")]
    public float rotLimitLow = 2.0f;
    public float rotLimitHigh = 50.0f;

    private Camera mainCam;
    private bool rightDown = false;
    private bool leftDown = false;
    private bool fwdDown = false;
    private bool aftDown = false;
    private bool zoomInDown = false;
    private bool zoomOutDown = false;
    private bool rightMouseDown = false;
    private float prevMousePos = 0.0f;

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

        Vector3 newRot = mainCam.transform.rotation.eulerAngles;

        if (Input.GetMouseButtonDown(1))
            rightMouseDown = true;
        else if (Input.GetMouseButtonUp(1))
            rightMouseDown = false;

        // Input handling for rotation
        if (rightMouseDown)
        {
            newRot = new Vector3(Math.Clamp(Input.mousePosition.y - prevMousePos, -1.0f, 1.0f) * dt * rotSensitivity,
                0.0f, 0.0f);

            mainCam.transform.Rotate(newRot);

            if (mainCam.transform.eulerAngles.x >= rotLimitHigh)
                mainCam.transform.Rotate(rotLimitHigh - mainCam.transform.eulerAngles.x, 0.0f, 0.0f);
            else if (mainCam.transform.eulerAngles.x <= rotLimitLow)
                mainCam.transform.Rotate(rotLimitLow - mainCam.transform.eulerAngles.x, 0.0f, 0.0f);

#if DEBUG_LOG
            Debug.Log(mainCam.transform.eulerAngles.x);
#endif
        }

        // Input handling for panning
        Vector3 newPos = mainCam.transform.position;
        if (Input.GetKeyDown(KeyCode.W))
            fwdDown = true;
        else if (Input.GetKeyUp(KeyCode.W))
            fwdDown = false;
        if (Input.GetKeyDown(KeyCode.S))
            aftDown = true;
        else if (Input.GetKeyUp(KeyCode.S))
            aftDown = false;
        if (Input.GetKeyDown(KeyCode.D))
            rightDown = true;
        else if (Input.GetKeyUp(KeyCode.D))
            rightDown = false;
        if (Input.GetKeyDown(KeyCode.A))
            leftDown = true;
        else if (Input.GetKeyUp(KeyCode.A))
            leftDown = false;

        if (fwdDown)
            newPos = new Vector3(newPos.x, newPos.y,
                Math.Clamp(newPos.z + panSensitivity * dt, -panLimitZ, panLimitZ));
        else if (aftDown)
            newPos = new Vector3(newPos.x, newPos.y,
                Math.Clamp(newPos.z - panSensitivity * dt, -panLimitZ, panLimitZ));
        if (rightDown)
            newPos = new Vector3(Math.Clamp(newPos.x + panSensitivity * dt,
                -panLimitX, panLimitX), newPos.y, newPos.z);
        else if (leftDown)
            newPos = new Vector3(Math.Clamp(newPos.x - panSensitivity * dt, -panLimitX, panLimitX),
                newPos.y, newPos.z);

        // Input handling for zooming
        // TODO: Add wheeeeeeel!
        if (Input.GetKeyDown(KeyCode.E))
            zoomInDown = true;
        else if (Input.GetKeyUp(KeyCode.E))
            zoomInDown = false;
        if (Input.GetKeyDown(KeyCode.Q))
            zoomOutDown = true;
        else if (Input.GetKeyUp(KeyCode.Q))
            zoomOutDown = false;

        if (zoomInDown)
            newPos = new Vector3(newPos.x, Math.Clamp(newPos.y - zoomSensitivity * dt, zoomLimitLow, zoomLimitHigh), newPos.z);
        else if (zoomOutDown)
            newPos = new Vector3(newPos.x, Math.Clamp(newPos.y + zoomSensitivity * dt, zoomLimitLow, zoomLimitHigh), newPos.z);

#if DEBUG_LOG
        if (mainCam.transform.position != newPos)
            Debug.Log("New pos: " + newPos);
#endif

        mainCam.transform.position = newPos;

        prevMousePos = Input.mousePosition.y;
    }
}
