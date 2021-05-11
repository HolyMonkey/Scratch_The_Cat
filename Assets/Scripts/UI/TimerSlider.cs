using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimerSlider : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Slider _slider;

    public float Value => _slider.value;

    private float _timeLeft;

    private void Start()
    {
        _timeLeft = _time;
    }

    private void Update()
    {
        _timeLeft -= Time.deltaTime;
        _slider.value = _timeLeft / _time;
    }

    public void DecreasSeconds(int seccondsCount)
    {
        _timeLeft -= seccondsCount;
        Shake();
    }

    private void Shake()
    {
        transform.DOShakePosition(0.2f, 10f, 50);
    }
}
