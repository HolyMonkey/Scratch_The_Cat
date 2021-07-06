using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class MouseCircleArea : MonoBehaviour
    {
        public event Action Coming;
        public event Action Out;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Animal animal))
            {
                Coming?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Animal animal))
            {
                Out?.Invoke();
            }
        }
    }
}

