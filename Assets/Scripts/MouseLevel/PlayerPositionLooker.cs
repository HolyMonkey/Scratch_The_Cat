using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class PlayerPositionLooker : MonoBehaviour
    {
        [SerializeField] private MouseCircleArea[] _circleAreas;
        
        private Dictionary<int, PlayerPositionType> _playerPositionTypes = new Dictionary<int, PlayerPositionType>()
        {
            {0, PlayerPositionType.Outside},
            {1, PlayerPositionType.InFrontierCircle},
            {2, PlayerPositionType.InInnerCircle}
        };
        
        private int _playerPositionTypeNumber;

        public event Action<PlayerPositionType> PositionChanged;

        private void OnEnable()
        {
            foreach (var circleArea in _circleAreas)
            {
                circleArea.Coming += OnComing;
                circleArea.Out += OnOut;
            }
        }

        private void OnDisable()
        {
            foreach (var circleArea in _circleAreas)
            {
                circleArea.Coming -= OnComing;
                circleArea.Out -= OnOut;
            }
        }

        public PlayerPositionType GetPositionType()
        {
            return _playerPositionTypes[_playerPositionTypeNumber];
        }

        private void OnComing()
        {
            _playerPositionTypeNumber++;
            PositionChanged?.Invoke(_playerPositionTypes[_playerPositionTypeNumber]);
        }

        private void OnOut()
        {
            _playerPositionTypeNumber--;
            PositionChanged?.Invoke(_playerPositionTypes[_playerPositionTypeNumber]);
        }
    }
}

