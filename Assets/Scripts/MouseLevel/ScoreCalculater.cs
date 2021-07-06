using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MouseLevel;
using UnityEngine;

namespace MouseLevel
{
    public class ScoreCalculater : MonoBehaviour
    {
        [SerializeField] private float _maxScore;
        [SerializeField] private PlayerPositionLooker _playerPositionLooker;
        [SerializeField] private MouseLevelInput _levelInput;
        [SerializeField, Range(1, 30)] private int _scoreLoseForSecond;
        [SerializeField] private ScoreByPosition[] _scoreByPositions;
        
        private float _currentScore;

        public float MaxValue => _maxScore;
        public float Score => _currentScore;

        public event Action ValueChanged;
        public event Action ScoreReached;
        public event Action LosingAllScore;
        public event Action ValueBurst;
        
        private void OnEnable()
        {
            _levelInput.Clicked += OnFirstClick;
        }

        private void OnDisable()
        {
            _levelInput.Clicked -= OnClick;
            _levelInput.Clicked -= OnFirstClick;
        }

        private void Start()
        {
            StartCoroutine(LoseScoreEverySecond());
        }

        private void OnFirstClick()
        {
            PlayerPositionType type = _playerPositionLooker.GetPositionType();
            float score = _scoreByPositions.First(s => s.PositionType == type).Score;
            if (score > 0)
            {
                _levelInput.Clicked -= OnFirstClick;
                _levelInput.Clicked += OnClick;
                _currentScore += score;
                MonitorCurrentValueAfterValueChange();
            }
        }
        
        private void OnClick()
        {
            PlayerPositionType type = _playerPositionLooker.GetPositionType();
            float score = _scoreByPositions.First(s => s.PositionType == type).Score;
            _currentScore += score;
            ValueBurst?.Invoke();
            MonitorCurrentValueAfterValueChange();
        }

        private IEnumerator LoseScoreEverySecond()
        {
            yield return new WaitWhile(() => _currentScore == 0);
            Debug.Log("Click");
            do
            {
                _currentScore -= _scoreLoseForSecond;
                ValueChanged?.Invoke();
                MonitorCurrentValueAfterValueChange();
                yield return new WaitForSeconds(1);
            } while (_currentScore > 0);
        }

        private void StopCalculate()
        {
            StopCoroutine(LoseScoreEverySecond());
        }
        
        private void MonitorCurrentValueAfterValueChange()
        {
            if (_currentScore >= _maxScore)
            {
                ScoreReached?.Invoke();
                StopCalculate();
                return;
            }

            if (_currentScore <= 0)
            {
                LosingAllScore?.Invoke();
                StopCalculate();
                return;
            }
        }
    }

    [Serializable]
    public class ScoreByPosition
    {
        public PlayerPositionType PositionType;
        public float Score;
    }
}

