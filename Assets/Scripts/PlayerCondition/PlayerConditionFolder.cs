using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerConditionFolder : MonoBehaviour
{
    [SerializeField] private float _conditionAddValue = 20f;
    [SerializeField] private float _conditionDistractValue = 5f;
    [SerializeField] private float _energyDistractValue = 20f;

    public float LevelEnergyCost => _energyDistractValue;

    private Dictionary<PlayerConditionName, float> _conditions;

    public readonly int MaxConditionValue = 100;
    private readonly int _minConditionValue = 0;

    public event Action ValueChanged;

    private void Awake()
    {
        if (PlayerConditionReload.TryLoad(out Dictionary<PlayerConditionName, float> dictionary))
        {
            _conditions = dictionary;

        }
        else
        {
            CreateNewDictionary();
        }
    }

    public PlayerConditionName GetLowestCondition()
    {
        return _conditions.Keys.OrderBy(x => _conditions[x]).Where(x => x != PlayerConditionName.Energy).First();
    }

    public float GetValueByConditionName(PlayerConditionName playerConditionName)
    {
        return _conditions[playerConditionName];
    }

    public void AddEnergy(int value)
    {
        AddValue(PlayerConditionName.Energy, value);
        SaveDictionary();
    }

    public void AddConditionValue(PlayerConditionName playerConditionName)
    {
        for (int condition = 0; condition < (int)PlayerConditionName.ConditionCount; condition++)
        {
            if (condition == (int)PlayerConditionName.Energy)
                continue;

            if (condition == (int)playerConditionName)
                AddValue((PlayerConditionName)condition, _conditionAddValue);
            else
                AddValue((PlayerConditionName)condition, -_conditionDistractValue);
        }

        AddValue(PlayerConditionName.Energy, -_energyDistractValue);
        SaveDictionary();
        ValueChanged?.Invoke();
    }

    public void RemoveConditionsValue()
    {
        AddValue(PlayerConditionName.Energy, -_energyDistractValue);
        SaveDictionary();
        ValueChanged?.Invoke();
    }

    private void AddValue(PlayerConditionName playerConditionName, float value)
    {
        _conditions[playerConditionName] = Mathf.Clamp(_conditions[playerConditionName] + value, _minConditionValue, MaxConditionValue);
    }

    private void CreateNewDictionary()
    {
        _conditions = new Dictionary<PlayerConditionName, float>()
        {
            {PlayerConditionName.Energy, 100},
            {PlayerConditionName.Cleanness, 40},
            {PlayerConditionName.Food, 40},
            {PlayerConditionName.Entertainment, 40}
        };
        
        SaveDictionary();
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
