using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine.SceneManagement;

public class WatchVideoForEnergy : MonoBehaviour, IRewardedVideoAdListener
{
    [SerializeField] private Stat _energy;
    [SerializeField] private float _energyForVideo;

    private string _appKey = "59adcbd92d73afa92eeacc7c8b9165224d14a1b9fdce1d53";

    private void Start ()
    {
        int adTypes = Appodeal.REWARDED_VIDEO;
        Appodeal.initialize(_appKey, adTypes, true);
        Appodeal.setRewardedVideoCallbacks(this);
    }

    public void ShowRewardedVideo ()
    {
        if (Appodeal.canShow(Appodeal.REWARDED_VIDEO) && !Appodeal.isPrecache(Appodeal.INTERSTITIAL))
            Appodeal.show(Appodeal.INTERSTITIAL);
    }

    public void onRewardedVideoClicked ()
    {
        Debug.Log("Clicked;");
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoClosed (bool finished)
    {
        Debug.Log("Closed;" + finished);
    }

    public void onRewardedVideoExpired ()
    {
    }

    public void onRewardedVideoFailedToLoad ()
    {
    }

    public void onRewardedVideoFinished (double amount, string name)
    {
        PlayerPrefs.SetFloat("Energy", PlayerPrefs.GetFloat("Energy") + _energyForVideo);
        PlayerPrefs.Save();
        gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    public void onRewardedVideoLoaded (bool precache)
    {
    }

    public void onRewardedVideoShowFailed ()
    {
    }

    public void onRewardedVideoShown ()
    {
    }
}
