using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConditionLooker : MonoBehaviour
{
    [SerializeField] private PlayerConditionViewMediator _conditionViewMediator;
    [SerializeField] private PlayerConditionName _playerConditionName;
    [SerializeField] private EnergyLooker _energyLooker;

    public void CalculateWinValue()
    {
        _conditionViewMediator.ShowAfterAddValue(_playerConditionName);
    }

    public void CalculateLoosValue()
    {
        _conditionViewMediator.ShowAfterRemoveValue();
    }
}
