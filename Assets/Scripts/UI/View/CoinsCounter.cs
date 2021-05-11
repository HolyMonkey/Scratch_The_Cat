using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinsCounter : MonoBehaviour
{
    public event UnityAction CoinsChanged;

    private int _currentCoins;

    public int TotalCoins { get; set; }

    private void Update()
    {
        if (_currentCoins < TotalCoins)
        {
            _currentCoins ++;
            CoinsChanged?.Invoke();
        }
    }
}
