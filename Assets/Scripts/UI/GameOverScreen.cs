using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Animator))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private float _fadeDuration = 0.4f;

    private CanvasGroup _canvasGroup;
    private Animator _animator;

    private void Awake ()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
    }

    public void Enable ()
    {
        _canvasGroup.DOFade(1, _fadeDuration);
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
        //_scoreCounter.enabled = true;
        _animator.Play("Open");
    }

    public void Init (int score, int coins, float food, float energy, float clean, float hapiness)
    {
        //_scoreCounter.TotalScore = score;
        _coinsCounter.TotalCoins = coins;

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);
        PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") + food);
        PlayerPrefs.SetFloat("Energy", PlayerPrefs.GetFloat("Energy") - energy);
        PlayerPrefs.SetFloat("Clean", PlayerPrefs.GetFloat("Clean") + clean);
        PlayerPrefs.SetFloat("Hapiness", PlayerPrefs.GetFloat("Hapiness") + hapiness);
        PlayerPrefs.Save();
    }
}
