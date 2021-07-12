using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WashLevel
{
    public abstract class WashingState : MonoBehaviour
    {
        [SerializeField] private int _maxValue;
        [SerializeField] private WashingItemType _washingItemType;

        public WashingItemType ItemType => _washingItemType;
        protected int MaxValue => _maxValue;
        
        public event Action StateComplited;
        public event Action ValueChanged;

        public float GetMaxValue()
        {
            return _maxValue;
        }
        
        public abstract void Wash();

        public virtual void Enter(){}

        protected void EndState()
        {
            StateComplited?.Invoke();
        }

        protected void NotifyOnValueChange()
        {
            ValueChanged?.Invoke();
        }
    }
}

