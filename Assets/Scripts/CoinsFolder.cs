using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsFolder : MonoBehaviour
{
    private readonly string _coinsSaveName = "CoinsPlayerPref";
    public int Coins { get; private set; }
    public int LastAddedCoins { get; private set; }

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_coinsSaveName))
        {
            Coins = PlayerPrefs.GetInt(_coinsSaveName);
        }
        else
        {
            Coins = 0;
        }
    }

    public void RemoveCoins(int coins)
    {
        Coins -= Coins;
        PlayerPrefs.SetInt(_coinsSaveName, Coins);
    }

    public void AddCoins(int coins)
    {
        Coins += coins;
        LastAddedCoins = coins;
        PlayerPrefs.SetInt(_coinsSaveName, Coins);
    }
}
