using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLevelInput : MonoBehaviour
{
    public event Action Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked?.Invoke();
        }
    }
}
