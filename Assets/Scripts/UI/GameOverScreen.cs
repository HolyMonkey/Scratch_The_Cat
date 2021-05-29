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
    private Save _save;

    private void Awake ()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
        _save = GetComponent<Save>();
    }

    public void Enable ()
    {
        _canvasGroup.DOFade(1, _fadeDuration);
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
        //_scoreCounter.enabled = true;
        _animator.Play("Open");
    }

    public void Init (int coins)
    {
        //_scoreCounter.TotalScore = score;

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);
        PlayerPrefs.Save();
        _save.enabled = true;
        _save.SaveCoins(coins);
    }
}
