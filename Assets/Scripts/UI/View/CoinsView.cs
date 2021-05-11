using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class CoinsView : MonoBehaviour
{
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private TMP_Text _coins;

    private int _currentCoins = 0;

    private void Awake()
    {
        _currentCoins = PlayerPrefs.GetInt("Coins");

        if (_currentCoins >= 1000)
            _coins.text = (_currentCoins / 1000).ToString() + "K";
        else
            _coins.text = _currentCoins.ToString();
    }

    private void Update()
    {
        _currentCoins = PlayerPrefs.GetInt("Coins");

        if (_currentCoins < 1000)
            _coins.text = (_currentCoins).ToString();
        else
            _coins.text = (_currentCoins / 1000).ToString() + "K";
    }

    public void ChangeCoinsCount(int value)
    {
        _currentCoins -= value;

        if (_currentCoins < 1000)
            _coins.text = (_currentCoins).ToString();
        else
            _coins.text = (_currentCoins / 1000).ToString() + "K";
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Coins", _currentCoins);
        PlayerPrefs.Save();
    }
}
