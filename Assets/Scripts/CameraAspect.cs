using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    [SerializeField, Range(0f, 120f)] private float horizontalFOV = 120f;

    private void Start()
    {
        Camera.main.fieldOfView = calcVertivalFOV(horizontalFOV, Camera.main.aspect);
    }
 
    private float calcVertivalFOV(float hFOVInDeg, float aspectRatio)
    {
        float hFOVInRads = hFOVInDeg * Mathf.Deg2Rad;  
        float vFOVInRads = 2 * Mathf.Atan(Mathf.Tan(hFOVInRads / 2) / aspectRatio);
        float vFOV = vFOVInRads * Mathf.Rad2Deg;
        return vFOV;
    }
}
