using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Animator))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private CoinsCounter _coinsCounter;

    private CanvasGroup _canvasGroup;
    private Animator _animator;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
    }

    public void Enable()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
        _scoreCounter.enabled = true;
        _animator.Play("Open");
    }

    public void Init(int score, int coins)
    {
        _scoreCounter.TotalScore = score;
        _coinsCounter.TotalCoins = coins;

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);
        PlayerPrefs.Save();
    }

}
