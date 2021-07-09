using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyLooker : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PlayerConditionFolder _conditionFolder;
    private PlayerConditionName _conditionName = PlayerConditionName.Energy;

    private void OnEnable()
    {
        _conditionFolder.ValueChanged += OnEnergyChanged;
    }

    private void OnDisable()
    {
        _conditionFolder.ValueChanged -= OnEnergyChanged;
    }

    private void OnEnergyChanged()
    {
        if (_conditionFolder.GetValueByConditionName(_conditionName) <= 0)
        {
            _gameOverScreen.ShowEnergyLost();
        }
    }
}
