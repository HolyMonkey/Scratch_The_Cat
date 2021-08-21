using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DestroyLevel
{
    public class PropsLooker : MonoBehaviour
    {
        [SerializeField] private List<Prop> _props;
        [SerializeField] private AudioSource _audioSource;
    
        public event Action CountChanged;
        public event Action AllPropDestroyеd;
        
        private void OnEnable()
        {
            foreach (var prop in _props)
            {
                prop.Destroyed += OnPropDestroy;
            }
        }
    
        private void OnDisable()
        {
            foreach (var prop in _props)
            {
                prop.Destroyed -= OnPropDestroy;
            }
        }
    
        public int GetPropsLength()
        {
            return _props.Count;
        }
    
        private void OnPropDestroy(Prop prop)
        {
            prop.Destroyed -= OnPropDestroy;
            _props.Remove(prop);
            CountChanged?.Invoke();
            _audioSource.Play();
            if (CheckPropsLength())
            {
                AllPropDestroyеd?.Invoke();
            }
        }
    
        private bool CheckPropsLength()
        {
            if (GetPropsLength() <= 0)
            {
                return true;
            }
    
            return false;
        }
    }
}