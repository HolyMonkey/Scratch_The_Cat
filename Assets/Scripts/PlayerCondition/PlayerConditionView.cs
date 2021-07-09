using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConditionView : MonoBehaviour
{
    [SerializeField] private PlayerConditionName _playerConditionName;
    [SerializeField] private Slider _slider;

    public PlayerConditionName ConditionName => _playerConditionName;

    public void SetMaxSliderValue(float value)
    {
        _slider.maxValue = value;
    }

    public void SetValue(float value)
    {
        _slider.value = value;
    }
}
