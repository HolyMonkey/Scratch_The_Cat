using System;
using System.Collections;
using System.Collections.Generic;
using MouseLevel;
using UnityEngine;

namespace DestroyLevel
{
    public class PropsValueMediator : MonoBehaviour
    {
        [SerializeField] private PropsLooker _propsLooker;
        [SerializeField] private LevelView _levelView;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private DeactivatorInputSystem _deactivatorInput;
        [SerializeField] private ScoreCalculate _scoreCalculate;
        private int _maxValue;

        private void OnEnable()
        {
            _propsLooker.CountChanged += OnCountChanged;
            _propsLooker.AllPropDestroyеd += OnAllPropDestroyеd;
        }

        private void OnDisable()
        {
            _propsLooker.CountChanged -= OnCountChanged;
            _propsLooker.AllPropDestroyеd -= OnAllPropDestroyеd;
        }

        private void Awake()
        {
            _maxValue = _propsLooker.GetPropsLength();
            _levelView.SetSliderMaxValue(_maxValue);
        }

        private void OnCountChanged()
        {
            int value = _maxValue - _propsLooker.GetPropsLength();
            _levelView.ShowNewValue(value);
        }

        private void OnAllPropDestroyеd()
        {
            _levelView.Hide();
            _scoreCalculate.StopCalculate();
            _gameOverScreen.ShowWin();
            _deactivatorInput.Deactivate();
        }
    }
}

