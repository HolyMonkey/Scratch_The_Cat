using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProgressSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetMaxValue(int maxValue)
    {
        _slider.maxValue = maxValue;
    }

    public void SetMaxValue(float maxValue)
    {
        _slider.maxValue = maxValue;
    }

    public void SetValue(float value)
    {
        _slider.value = value;
    }

    public void SetValue(int value)
    {
        _slider.value = value;
    }
}
