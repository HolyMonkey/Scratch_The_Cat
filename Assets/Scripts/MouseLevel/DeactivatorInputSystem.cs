using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class DeactivatorInputSystem : MonoBehaviour
    {
        [SerializeField] private PlayerInput _mouseLevelInit;

        public void Deactivate()
        {
            _mouseLevelInit.enabled = false;
        }
    }
}

