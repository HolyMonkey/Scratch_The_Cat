using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class DeactivatorInputSystem : MonoBehaviour
    {
        [SerializeField] private MouseLevelInput _mouseLevelInput;

        public void Deactivate()
        {
            _mouseLevelInput.enabled = false;
        }
    }
}

