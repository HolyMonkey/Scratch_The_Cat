using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] protected string SaveTitle;
    [SerializeField] protected float ReducePerMinute = 0.015f;

    public string SaveName => SaveTitle;

    public void Init (float totalMinutes)
    {
        PlayerPrefs.SetFloat(SaveTitle, PlayerPrefs.GetFloat(SaveTitle) - (ReducePerMinute * totalMinutes));
        PlayerPrefs.Save();

        Slider.value = PlayerPrefs.GetFloat(SaveTitle);
    }
}

    //[SerializeField] private string _statName;

    //private Slider _slider;

    //public string StatName => _statName;

    //private void Awake ()
    //{
    //    _slider = GetComponent<Slider>();

    //    if (!PlayerPrefs.HasKey(_statName))
    //    {
    //        if (_statName != "Energy")
    //            PlayerPrefs.SetFloat(_statName, Random.Range(0, 1));
    //        else
    //            PlayerPrefs.SetFloat(_statName, 1);

    //        PlayerPrefs.Save();
    //    }
    //}

    //public void SetValue (float value)
    //{
    //    if (value < 0)
    //        _slider.value = 0;
    //    else if (value > 1)
    //        _slider.value = 1;
    //    else
    //        _slider.value = value;

    //    PlayerPrefs.SetFloat(_statName, _slider.value);
    //    PlayerPrefs.Save();
    //}

    //public void OnValueChanged ()
    //{
    //    PlayerPrefs.SetFloat(_statName, _slider.value);
    //    PlayerPrefs.Save();
    //}
