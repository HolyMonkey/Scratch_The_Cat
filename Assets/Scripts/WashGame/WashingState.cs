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
        [SerializeField] protected AudioSource AudioSource;
        [SerializeField] private InputHandler _handler;

        public WashingItemType ItemType => _washingItemType;
        protected int MaxValue => _maxValue;
        
        public event Action StateComplited;
        public event Action ValueChanged;

        private void OnEnable()
        {
            _handler.Clicked += PlaySound;
            _handler.UnClicked += StopSound;
        }

        private void OnDisable()
        {
            _handler.Clicked -= PlaySound;
            _handler.UnClicked -= StopSound;
        }

        public float GetMaxValue()
        {
            return _maxValue;
        }
        
        public abstract void Wash();

        public void Enter()
        {
            AudioSource.Play();
            EnterState();
        }

        protected virtual void EnterState(){}

        protected void EndState()
        {
            StateComplited?.Invoke();
            AudioSource.Stop();
        }

        protected void NotifyOnValueChange()
        {
            ValueChanged?.Invoke();
        }

        private void PlaySound() => AudioSource.Play();

        private void StopSound() => AudioSource.Pause();
    }
}

