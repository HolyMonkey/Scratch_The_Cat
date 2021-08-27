using UnityEngine;
using UnityEngine.Events;

public class AdsCoinMultiplyer : MonoBehaviour
{
    public event UnityAction<int> CoinsMultiplyed;

    [SerializeField] private AdsActivator _adsActivator;
    [SerializeField] private CoinsFolder _coinsFolder;
    [SerializeField] private int _multiplyer = 3;

    public bool IsInvoked { get; private set; }

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
        AppMetricaStatistics.SendRewarded(RewardedVideoPlacement.Coins);
        _coinsFolder.AddCoins(_coinsFolder.LastAddedCoins);
        CoinsMultiplyed?.Invoke(_coinsFolder.LastAddedCoins * _multiplyer);
        IsInvoked = true;
    }
}