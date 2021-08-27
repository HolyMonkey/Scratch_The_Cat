using UnityEngine;
using Newtonsoft.Json;

public class AppMetricaStatistics : MonoBehaviour
{
    [SerializeField] private AdsCoinMultiplyer _coinMultiplyer;
    [SerializeField] private SceneNameFolder _sceneNameFolder;

    public void SendLevelStart(string sceneName)
    {
        IncreaseLevelCount();
        int currentLevelCount = GetLevelCount();
        string levelName = SceneNameFolder.GetLevelName(sceneName);

        AppMetrica.Instance.ReportEvent("level_start", JsonConvert.SerializeObject(new { level_name = levelName, level_count = currentLevelCount }));
        print("level_start - " + JsonConvert.SerializeObject(new { level_name = levelName, level_count = currentLevelCount }));
    }

    public void SendLevelWin(string sceneName)
    {
        int currentLevelCount = GetLevelCount();
        bool x2CoinsPressed = _coinMultiplyer.IsInvoked;
        string levelName = SceneNameFolder.GetLevelName(sceneName);

        AppMetrica.Instance.ReportEvent("level_win", JsonConvert.SerializeObject(new { level_name = levelName, level_count = currentLevelCount, x2_coins = x2CoinsPressed }));
        print("level_win - " + JsonConvert.SerializeObject(new { level_name = levelName, level_count = currentLevelCount, x2_coins = x2CoinsPressed }));
    }

    public void SendLevelLose(string sceneName)
    {
        string levelName = SceneNameFolder.GetLevelName(sceneName);
        int currentLevelCount = GetLevelCount();

        AppMetrica.Instance.ReportEvent("level_lose", JsonConvert.SerializeObject(new { level_name = levelName, level_count = currentLevelCount }));
        print("level_lose - " + JsonConvert.SerializeObject(new { level_name = levelName, level_count = currentLevelCount }));
    }

    public static void SendRewarded(RewardedVideoPlacement placement)
    {
        string placementName = placement.ToString().ToLower();

        AppMetrica.Instance.ReportEvent("rewarded", JsonConvert.SerializeObject(new { placement = placementName }));
        print("rewarded - " + JsonConvert.SerializeObject(new { placement = placementName }));
    }

    public static void SendUnlockRandom()
    {
        AppMetrica.Instance.ReportEvent("unlock_random", JsonConvert.SerializeObject(new { press_unlock = true }));
        print("unlock_random - " + JsonConvert.SerializeObject(new { press_unlock = true }));
    }

    private void IncreaseLevelCount()
    {
        int currentLevelCount = PlayerPrefs.GetInt(PlayerPrefName.LevelCount, 0);
        currentLevelCount++;
        PlayerPrefs.SetInt(PlayerPrefName.LevelCount, currentLevelCount);
    }

    private int GetLevelCount()
    {
        return PlayerPrefs.GetInt(PlayerPrefName.LevelCount, 0);
    }
}