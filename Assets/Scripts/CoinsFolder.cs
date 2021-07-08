using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsFolder : MonoBehaviour
{
    public int Coins { get; private set; }
    public int LastAddedCoins { get; private set; }

    private void Awake()
    {
        if (PlayerPrefs.HasKey(PlayerPrefName.Coin))
        {
            Coins = PlayerPrefs.GetInt(PlayerPrefName.Coin);
        }
        else
        {
            Coins = 0;
        }
    }

    public void RemoveCoins(int coins)
    {
        Coins -= Coins;
        PlayerPrefs.SetInt(PlayerPrefName.Coin, Coins);
    }

    public void AddCoins(int coins)
    {
        if (coins < 0)
        {
            LastAddedCoins = 0;
        }
        else
        {
            LastAddedCoins = coins;
        }
        
        Coins += LastAddedCoins;
        PlayerPrefs.SetInt(PlayerPrefName.Coin, Coins);
    }
}
