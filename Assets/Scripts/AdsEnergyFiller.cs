using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine;

public class AdsEnergyFiller : MonoBehaviour
{
    [SerializeField] private PlayerConditionViewMediator _conditionMediator;
    [SerializeField] private AdsActivator _adsActivator;

    private void OnEnable()
    {
        _adsActivator.RewardedVideoWatched += OnVideoWatched;
    }

    private void OnDisable()
    {
        _adsActivator.RewardedVideoWatched -= OnVideoWatched;
    }

    private void OnVideoWatched()
	{
        _conditionMediator.ShowAfterAddFullEnergy();
	}
}