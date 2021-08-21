using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class MouseLevelInput : PlayerInput
    {
        public event Action Clicked;

        [SerializeField] private Cursor _cursor;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Clicked?.Invoke();
            }
        }
    }
}
