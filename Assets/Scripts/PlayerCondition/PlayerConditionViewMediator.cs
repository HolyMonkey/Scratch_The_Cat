using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConditionViewMediator : MonoBehaviour
{
    [SerializeField] private PlayerConditionView[] _conditionViews;
    [SerializeField] private PlayerConditionFolder _playerConditionFolder;

    private void Start()
    {
        Show();
    }

    public void ShowAfterAddValue(PlayerConditionName playerConditionName)
    {
        _playerConditionFolder.AddConditionValue(playerConditionName);
        Show();
    }

    public void ShowAfterRemoveValue()
    {
        _playerConditionFolder.RemoveConditionsValue();
        Show();
    }

    public void ShowAfterAddFullEnergy()
    {
        _playerConditionFolder.AddEnergy(_playerConditionFolder.MaxConditionValue);
        Show();
    }

    public void ShowAfterAddEnergy(int value)
    {
        _playerConditionFolder.AddEnergy(value);
        Show();
    }    

    public void Show()
    {
        foreach (var conditionView in _conditionViews)
        {
            conditionView.SetMaxSliderValue(_playerConditionFolder.MaxConditionValue);
            float value = _playerConditionFolder.GetValueByConditionName(conditionView.ConditionName);
            conditionView.SetValue(value);
            Debug.Log(conditionView.ConditionName +" " + value);
        }
    }
}
