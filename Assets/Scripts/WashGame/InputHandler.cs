using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WashLevel
{
    public class InputHandler : PlayerInput
    {
        public event Action Clicked;
        public event Action MouseDraging;
        public event Action UnClicked;

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Clicked?.Invoke();
            }

            if (Input.GetMouseButton(0))
            {
                MouseDraging?.Invoke();
            }

            if (Input.GetMouseButtonUp(0))
            {
                UnClicked?.Invoke();
            }
        }
    }   
}
