using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] private Food _food;
    [SerializeField] private Energy _energy;
    [SerializeField] private Purity _purity;
    [SerializeField] private Hapiness _hapiness;

    [SerializeField] protected float MinRandomSliderValue = 0.25f;
    [SerializeField] protected float MaxRandomSliderValue = 1f;

    private Stat[] _stats;
    private TimeSpan _timeSpan;
    private string _saveTitle = "LastSession";

    private void Start ()
    {
        _stats = new Stat[4];
        _stats[0] = _food;
        _stats[1] = _energy;
        _stats[2] = _purity;
        _stats[3] = _hapiness;

        CheckSave();
        CountTime();
    }

    private void CheckSave ()
    {
        if (!PlayerPrefs.HasKey(_saveTitle))
            PlayerPrefs.SetString(_saveTitle, DateTime.Now.ToString());

        WhatTimeIsIt();

        foreach (var stat in _stats)
        {
            if (!PlayerPrefs.HasKey(stat.SaveName))
                PlayerPrefs.SetFloat(stat.SaveName, Random.Range(MinRandomSliderValue, MaxRandomSliderValue));

        }
        PlayerPrefs.Save();
    }

    private void WhatTimeIsIt ()
    {
        _timeSpan = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString(_saveTitle));
    }

    public void SaveNewLastSession ()
    {
        PlayerPrefs.SetString(_saveTitle, DateTime.Now.ToString());
        PlayerPrefs.Save();
    }

    private void CountTime ()
    {
        int totalMinutes = Convert.ToInt32(_timeSpan.TotalMinutes);
        Debug.Log("Total minutes - " + totalMinutes);

        foreach (var stat in _stats)
            Initialize(stat, totalMinutes);

        SaveNewLastSession();
    }

    private void Initialize (Stat stat, float totalMinutes)
    {
        stat.Init(totalMinutes);
    }
}
