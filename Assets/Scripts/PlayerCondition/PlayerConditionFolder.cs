using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PlayerConditionFolder : MonoBehaviour
{
    private Dictionary<PlayerConditionName, float> _conditions;
    private float _conditionValueSpeedFall = 5f;
    private float _conditionAddMultipler = 4f;

    public readonly float MaxConditionValue = 100f;
    private readonly float _minConditionValue = 0;

    public event Action ValueChanged;

    private void Awake()
    {
        if (PlayerConditionReload.TryLoad(out Dictionary<PlayerConditionName, float> dictionary))
        {
            _conditions = dictionary;
            if (TryGetConditionsChangesByTime(out float value))
            {
                AddValue(PlayerConditionName.Energy, value);
                RemoveValue(PlayerConditionName.Energy, -value);
                PlayerConditionReload.Save(_conditions);
            }

        }
        else
        {
            CreateNewDictionary();
        }
    }

    public float GetValueByConditionName(PlayerConditionName playerConditionName)
    {
        return _conditions[playerConditionName];

    }

    public void AddEnergy()
    {
        AddValue(PlayerConditionName.Energy, 100);
        SaveDictionary();
    }

    public void AddConditionValue(PlayerConditionName playerConditionName)
    {
        float addValue = _conditionAddMultipler * _conditionValueSpeedFall;
        AddValue(playerConditionName, addValue);
        float removeValue = -_conditionValueSpeedFall;
        RemoveValue(playerConditionName, removeValue);
        SaveDictionary();
        ValueChanged?.Invoke();
    }

    public void RemoveConditionsValue()
    {
        float value = -_conditionValueSpeedFall;
        RemoveValue(default, value);
        SaveDictionary();
        ValueChanged?.Invoke();
    }

    private void AddValue(PlayerConditionName playerConditionName, float value)
    {
        if (CheckPosibleAddValue(playerConditionName, value))
        {
            SetConditionValue(playerConditionName, value);
        }
        else
        {
            SetMaxValue(playerConditionName);
        }
    }

    private void RemoveValue(PlayerConditionName playerConditionName, float value)
    {

        foreach (var valueKey in _conditions.Keys.ToList())
        {
            if (valueKey == playerConditionName)
            {
                break;
            }
            
            if (CheckPosibleAddValue(valueKey, value))
            {
                SetConditionValue(valueKey, value);
            }
            else
            {
                SetMinValue(valueKey);
            }
        }
    }

    private void CreateNewDictionary()
    {
        _conditions = new Dictionary<PlayerConditionName, float>()
        {
            {PlayerConditionName.Energy, 100},
            {PlayerConditionName.Cleanness, 0},
            {PlayerConditionName.Food, 0},
            {PlayerConditionName.Entertainment, 0}
        };
        
        SaveDictionary();
    }

    private bool CheckPosibleAddValue(PlayerConditionName playerConditionName, float value)
    {
        float currentValue = _conditions[playerConditionName] + value;
        if (currentValue > MaxConditionValue || currentValue < _minConditionValue)
        {
            return false;
        }

        return true;
    }

    private void SetConditionValue(PlayerConditionName playerConditionName, float value)
    {
        _conditions[playerConditionName] += value;
    }

    private void SetMaxValue(PlayerConditionName playerConditionName)
    {
        _conditions[playerConditionName] = MaxConditionValue;
    }

    private void SetMinValue(PlayerConditionName playerConditionName)
    {
        _conditions[playerConditionName] = _minConditionValue;
    }

    private void SaveDictionary()
    {
        PlayerConditionReload.Save(_conditions);
    }

    private bool TryGetConditionsChangesByTime(out float value)
    {
        if (TimeOutOfGameCalculator.TryCalculate(out value))
        {
            return true;
        }
        else
        {
            value = 0;
            return false;
        }
    }
}
