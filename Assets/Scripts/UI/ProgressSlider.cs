using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProgressSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private RectTransform _rectTransform;
    private Vector2 _startPosition;

    public float Value => _slider.value;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.rect.position;
    }

    public void ChangeValue(int maxValue, int currentValue, bool shake = true)
    {
        _slider.value = 1f * currentValue / maxValue;
        if (shake)
            Shake();
    }

    public void ChangeValue(float value, bool shake = true)
    {
        _slider.value += value;
        if (shake)
            Shake();
    }
    public void ChangeValue(float maxValue, float currentValue, bool shake = true)
    {
        _slider.value = currentValue / maxValue;
        if (shake)
            Shake();
    }

    public void SetValue(float value)
    {
        _slider.value = value;
    }


    private void Shake()
    {
        transform.DOComplete();
        transform.DOShakePosition(0.2f, 10f, 50, 0, false, false);
    }
}
