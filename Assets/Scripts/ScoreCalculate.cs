using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ScoreCalculate : MonoBehaviour
{
    [SerializeField] private CoinsFolder _coinsFolder;
    private float _score = 1000;
    private float _scoreToCoinMultipler = 10f;
    

    private void Update()
    {
        _score -= Time.deltaTime * 10;
    }

    public void StartCalculate()
    {
        enabled = true;
    }

    public void StopCalculate()
    {
        int value = Mathf.RoundToInt(_score / _scoreToCoinMultipler);
        _coinsFolder.AddCoins(value);
    }

    public void SetPenalty(float value)
    {
        _score -= value;
    }
}
