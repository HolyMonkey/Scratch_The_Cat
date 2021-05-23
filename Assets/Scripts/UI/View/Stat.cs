using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Stat : MonoBehaviour
{
    [SerializeField] private string _statName;

    private Slider _slider;

    public string StatName => _statName;
    
    private void Start ()
    {
        _slider = GetComponent<Slider>();
        Refresh();
    }

    public void Refresh ()
    {
        if (!PlayerPrefs.HasKey(_statName))
        {
            PlayerPrefs.SetFloat(_statName, 0);
            PlayerPrefs.Save();
        }
        else
        {
            _slider.value = PlayerPrefs.GetFloat(_statName);
        }
    }

    public void OnValueChanged ()
    {
        PlayerPrefs.SetFloat(_statName, _slider.value);
    }

    public float GetSliderValue ()
    {
        return _slider.value;
    }
}
