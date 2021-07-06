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

    [SerializeField] private GameOverText _gameOverText;

    private CanvasGroup _canvasGroup;
    private Animator _animator;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
    }

    public void ShowWin()
    {
        _gameOverText.ShowWinText();
        Enable();
    }

    public void ShowLose()
    {
        _gameOverText.ShowLoseText();
        Enable();
    }

    private void Enable()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
        _scoreCounter.enabled = true;
        _animator.Play("Open");
    }
}
