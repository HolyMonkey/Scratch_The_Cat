using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WashLevel;

namespace WashLevel
{
    public class ScatchState : WashingState
    {
        [SerializeField] private float _valueBurst;
        private Vector3 _previousPosition;
        private float _value;

        public override void Wash()
        {
            int previousValue = (int) _value;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Animal animal))
                {
                    float delta = 0.5f;
                    if (Vector3.Distance(hitInfo.point, _previousPosition) >= delta)
                    {
                        _value += _valueBurst * Time.deltaTime;
                        if (previousValue < (int) _value)
                        {
                            NotifyOnValueChange();
                        }
                    }

                    _previousPosition = hitInfo.transform.position;
                }
            }

            if (_value > MaxValue)
            {
                EndState();
            }
        }
    }
}
