using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Animator))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private SceneType _sceneType;
    [SerializeField] private CoinView _coinView;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private CoinsFolder _coinsFolder;
    [SerializeField] private GameOverText _gameOverText;
    [SerializeField] private LevelConditionLooker _levelConditionLooker;
    [SerializeField] private AdsCoinMultiplyer _coinMultiplyer;

    private CanvasGroup _canvasGroup;
    private Animator _animator;
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _coinMultiplyer.CoinsMultiplyed += SetCoinsValue;
    }

    private void OnDisable()
    {
        _coinMultiplyer.CoinsMultiplyed -= SetCoinsValue;
    }

    public void ShowWin()
    {
        _gameOverText.ShowWinText();
        _startButton.SetWinButtonEffect(_sceneType);
        _levelConditionLooker.CalculateWinValue();
        Enable();
    }

    public void ShowLose()
    {
        _gameOverText.ShowLoseText();
        _startButton.SetLoseButtonEffect(_sceneType);
        _levelConditionLooker.CalculateLoosValue();
        Enable();
    }

    public void ShowEnergyLost()
    {
        _gameOverText.ShowEnergyLostText();
        _startButton.SetLoseEnergyButtonEffect();
    }

    private void Enable()
    {
        SetCoinsValue(_coinsFolder.LastAddedCoins);
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
        _animator.Play("Open");
    }

    private void SetCoinsValue(int levelValue)
    {
        int coinsByLevel = levelValue;
        int allCoins = _coinsFolder.Coins;
        
        _coinView.SetCoins(coinsByLevel, allCoins);
    }
}
