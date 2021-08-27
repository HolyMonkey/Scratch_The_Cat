using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Sprite _energyButtonSprite;
    [SerializeField] private AdsActivator _adsActivator;
    [SerializeField] private PlayerConditionViewMediator _conditionMediator;
    [SerializeField] private SceneNameFolder _sceneNameFolder;
    [SerializeField] private AppMetricaStatistics _metricaStats;

    public bool IsWin => _isWin;

    private Action ButtohHandler;
    private string _nextScene;
    private bool _isLowEnergy;
    private bool _isWin;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void SetLoseButtonEffect(SceneType type)
    {
        _isWin = false;
        _nextScene = _sceneNameFolder.GetNextScene();
        ButtohHandler += ChangeLevel;
    }

    public void SetWinButtonEffect(SceneType type)
    {
        _isWin = true;
        _nextScene = _sceneNameFolder.GetNextScene();
        ButtohHandler += ChangeLevel;
    }

    public void SetLoseEnergyButtonEffect()
    {
        _button.image.sprite = _energyButtonSprite;
        ColorBlock colorBlock = _button.colors;
        Color color = colorBlock.disabledColor;
        color.a = 1;
        colorBlock.disabledColor = color;
        _button.colors = colorBlock;

        _isLowEnergy = true;
        _nextScene = _sceneNameFolder.GetNextScene();
    }

    private void ChangeLevel()
    {
        if (_isWin)
            _metricaStats.SendLevelWin(SceneManager.GetActiveScene().name);

        if (_nextScene != _sceneNameFolder.GetMenuScene())
            _metricaStats.SendLevelStart(_nextScene);
        SceneManager.LoadScene(_nextScene);
    }

    private void OnButtonClick()
    {
        if (_isLowEnergy)
        {
            if (_adsActivator.IsRewardedVideoReady())
            {
                _adsActivator.ShowRewardedVideo();
                _adsActivator.RewardedVideoWatched += OnRewardedVideoWatched;
                _adsActivator.RewardedVideoWatched += ChangeLevel;
            }
            else
            {
                _nextScene = _sceneNameFolder.GetMenuScene();
                ChangeLevel();
            }
        }
        else
        {
            ButtohHandler?.Invoke();
        }
    }

    private void OnRewardedVideoWatched()
    {
        AppMetricaStatistics.SendRewarded(RewardedVideoPlacement.Energy);
        _conditionMediator.ShowAfterAddFullEnergy();
    }
}