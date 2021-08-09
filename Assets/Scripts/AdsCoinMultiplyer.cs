using AppodealAds.Unity.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdsCoinMultiplyer : MonoBehaviour
{
    public event UnityAction<int> CoinsMultiplyed;

    [SerializeField] private AdsActivator _adsActivator;
    [SerializeField] private CoinsFolder _coinsFolder;

    private void OnEnable()
    {
        _adsActivator.RewardedVideoWatched += OnVideoWatched;
    }

    private void OnDisable()
    {
        _adsActivator.RewardedVideoWatched -= OnVideoWatched;
    }

    public void OnVideoWatched()
    {
        _coinsFolder.AddCoins(_coinsFolder.LastAddedCoins);
        CoinsMultiplyed?.Invoke(_coinsFolder.LastAddedCoins * 2);
    }
}