using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public static class TimeOutOfGameCalculator
{
    private static readonly float _dataValueVultiplerByHour = 3f;
    private static readonly string _dataTimeSaveName = "LastData";
    
    public static bool TryCalculate(out float value)
    {
        if (PlayerPrefs.HasKey(_dataTimeSaveName))
        {
            value = Calculate();
            return true;
        }

        value = 0;
        return false;
    }

    private static float Calculate()
    {
        string lastDate = PlayerPrefs.GetString(_dataTimeSaveName);
        System.TimeSpan timeSpan = System.DateTime.Now - Convert.ToDateTime(lastDate);
        float value = (timeSpan.Days * 24 + timeSpan.Hours) * _dataValueVultiplerByHour;
        return value;
    }

    public static void SaveLastConditionUpdateTime()
    {
        string data = System.DateTime.Now.ToString();
        PlayerPrefs.SetString(_dataTimeSaveName, data);
    }
}
