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
        [SerializeField] private AudioSource _audioSource;

        public WashingItemType ItemType => _washingItemType;
        public AudioSource AudioSource => _audioSource;
        public bool IsWashing { get; private set; } = true;
        protected int MaxValue => _maxValue;
        
        public event Action StateComplited;
        public event Action ValueChanged;

        public float GetMaxValue()
        {
            return _maxValue;
        }
        
        public abstract void Wash();

        public void Enter()
        {
            EnterState();
        }

        protected virtual void EnterState(){}

        protected void EndState()
        {
            IsWashing = false;
            StateComplited?.Invoke();
        }

        protected void NotifyOnValueChange()
        {
            ValueChanged?.Invoke();
        }
    }
}