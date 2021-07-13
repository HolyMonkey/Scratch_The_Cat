using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCoinView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CoinsFolder _coinsFolder;

    private void Start()
    {
        int coins = _coinsFolder.Coins;

        if (coins > 1000)
        {
            _text.text = coins / 1000 + "K";
        }
        else
        {
            _text.text = _coinsFolder.Coins.ToString();
        }
    }
}
