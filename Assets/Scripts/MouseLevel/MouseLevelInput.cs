using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class MouseLevelInput : PlayerInput
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
}
