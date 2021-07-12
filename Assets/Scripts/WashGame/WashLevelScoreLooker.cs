using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace WashLevel
{
    public class WashLevelScoreLooker : MonoBehaviour
    {
        [SerializeField] private ScoreMediator _scoreMediator;
        [SerializeField] private WashingState[] _washingStates;
        [SerializeField] private ScoreCalculate _scoreCalculate;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private Particle _particle;
        private float _value;
        private float _maxValue;

        private void OnEnable()
        {
            foreach (var washingState in _washingStates)
            {
                washingState.ValueChanged += OnValueChanged;
            }
        }

        private void OnDisable()
        {
            foreach (var washingState in _washingStates)
            {
                washingState.ValueChanged -= OnValueChanged;
            }
        }

        private void Awake()
        {
            _maxValue= 0f;
            foreach (var washingState in _washingStates)
            {
                _maxValue += washingState.GetMaxValue();
            }

            _scoreMediator.SetMaxValue(_maxValue);
        }

        private void OnValueChanged()
        {
            _value++;
            _scoreMediator.SetSliderValue(_value);
            int valueForScoreUI = (int) (_value * 10);
            _scoreMediator.ShowScoreValue(valueForScoreUI);

            if (_value >= _maxValue)
            {
                _scoreMediator.Hide();
                _particle.PlayWin();
                _scoreCalculate.StopCalculate();
                _gameOverScreen.ShowWin();
            }
        }
    }
}

