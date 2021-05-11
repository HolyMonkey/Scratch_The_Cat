using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class HappinesSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _startValue;
    [SerializeField] private float _fillStep;

    public float Value => _slider.value;

    public event UnityAction BarIsFull;

    private void Start()
    {
        _slider.value = _startValue;
    }

    public void ChangeValue(float value)
    {
        _slider.value += value * _fillStep;
    }

    public void Shake()
    {
        transform.DOShakePosition(0.2f, 10f, 50);
    }
}
