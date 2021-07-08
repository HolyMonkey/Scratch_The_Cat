using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class RunnerGameSliderValue : MonoBehaviour
    {
        [SerializeField] private Transform _endPosition;
        [SerializeField] private ScoreMediator _scoreMediator;
        private Transform _player;
        private float _maxValue;

        private void Start()
        {
            float maxDistance = Vector3.Distance(_player.position, _endPosition.position);
            _maxValue = maxDistance;
            _scoreMediator.SetMaxValue(maxDistance);
        }

        private void Update()
        {
            float distance = Vector3.Distance(_player.position, _endPosition.position);
            float value = _maxValue - distance;
            _scoreMediator.SetSliderValue(value);
        }

        public void SetPlayerTransform(Transform transform)
        {
            _player = transform;
        }
    }   
}
