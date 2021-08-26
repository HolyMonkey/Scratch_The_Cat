using System.Collections;
using System.Collections.Generic;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine;
using UnityEngine.Events;

public class AdsActivator : MonoBehaviour, IRewardedVideoAdListener
{
    public event UnityAction RewardedVideoWatched;

    private void Start()
    {
        Appodeal.setLogLevel(Appodeal.LogLevel.Debug);
        Appodeal.initialize("ef8b1731c3d35866cf95edcde6ae3136984ea54d1d5392b3", Appodeal.REWARDED_VIDEO);
        Appodeal.setRewardedVideoCallbacks(this);
    }

    public void ShowRewardedVideo()
    {
        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
            Appodeal.show(Appodeal.REWARDED_VIDEO);
    }

    public bool IsRewardedVideoReady() => Appodeal.isLoaded(Appodeal.REWARDED_VIDEO);

    public void onRewardedVideoLoaded(bool precache)
    {
        
    }

    public void onRewardedVideoFailedToLoad()
    {
        
    }

    public void onRewardedVideoShowFailed()
    {
        
    }

    public void onRewardedVideoShown()
    {
        
    }

    public void onRewardedVideoFinished(double amount, string name)
    {
        RewardedVideoWatched?.Invoke();
    }

    public void onRewardedVideoClosed(bool finished)
    {
        
    }

    public void onRewardedVideoExpired()
    {
        
    }

    public void onRewardedVideoClicked()
    {
        
    }
}