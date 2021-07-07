using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinView : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsByLevel;
    [SerializeField] private TMP_Text _allCoins;

    public void SetCoins(int coins, int maxCoins)
    {
        _coinsByLevel.text = "SCORE: " + coins.ToString();

        string maxCoinsText;
        if (maxCoins > 1000)
        {
            maxCoinsText = (maxCoins / 1000) + "K";
        }
        else
        {
            maxCoinsText = maxCoins.ToString();
        }

        _allCoins.text = maxCoinsText;
    }
}
