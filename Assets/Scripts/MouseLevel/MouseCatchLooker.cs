using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class MouseCatchLooker : MonoBehaviour
    {
        [SerializeField] private MouseMover _mouseMover;
        [SerializeField] private MouseLevelInput _mouseLevelInput;
        [SerializeField] private PlayerPositionLooker _playerPositionLooker;
        [SerializeField] private AudioSource _audioSource;

        private void OnEnable()
        {
            _mouseLevelInput.Clicked += OnClick;
        }

        private void OnDisable()
        {
            _mouseLevelInput.Clicked -= OnClick;
        }

        private void OnClick()
        {
            _audioSource.Play();
            if (_playerPositionLooker.GetPositionType() != PlayerPositionType.Outside)
            {
                _mouseMover.Catch();
            }
        }
    }
}

