using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class ScoreValueMediator : MonoBehaviour
    {
        [SerializeField] private ScoreCalculater _scoreCalculater;
        [SerializeField] private LevelVeiw _levelVeiw;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private DeactivatorInputSystem _deactivatorInputSystem;

        private float _perviousScore;
        
        private void OnEnable()
        {
            _scoreCalculater.ValueChanged += OnValueChanged;
            _scoreCalculater.LosingAllScore += OnLevelLose;
            _scoreCalculater.ScoreReached += OnLevelWin;
            _scoreCalculater.ValueBurst += OnValueBurst;
        }

        private void OnDisable()
        {
            _scoreCalculater.ValueChanged -= OnValueChanged;
            _scoreCalculater.LosingAllScore -= OnLevelLose;
            _scoreCalculater.ScoreReached -= OnLevelWin;
            _scoreCalculater.ValueBurst -= OnValueBurst;
        }
        
        private void Awake()
        {
            SetMaxValue();
        }

        private void OnValueBurst()
        {
            float score = _scoreCalculater.Score;
            if (_perviousScore < score)
            {
                _levelVeiw.ShowSuccess();
            }
            else
            {
                _levelVeiw.ShowFail();
            }
            OnValueChanged();
        }

        private void OnValueChanged()
        {
            float score = _scoreCalculater.Score;
            _levelVeiw.ShowNewValue(score);
            _perviousScore = score;
        }

        private void SetMaxValue()
        {
            _levelVeiw.SetSliderMaxValue(_scoreCalculater.MaxValue);
        }

        private void OnLevelLose()
        {
            _gameOverScreen.ShowLose();
            _deactivatorInputSystem.Deactivate();
        }

        private void OnLevelWin()
        {
            _gameOverScreen.ShowWin();
            _levelVeiw.ShowWin();
            _deactivatorInputSystem.Deactivate();
        }
    }
}
