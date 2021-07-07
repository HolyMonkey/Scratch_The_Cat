using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedEndGameLooker : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private FeedGameMover _feedGameMover;
    [SerializeField] private FeedGame _feedGame;
    [SerializeField] private ScoreCalculate _scoreCalculate;
    [SerializeField] private Particle _particle;

    private void OnEnable()
    {
        _feedGame.BowlReached += OnBowlReached;
        _feedGameMover.TargetReached += OnTargetReached;
    }

    private void OnDisable()
    {
        _feedGame.BowlReached -= OnBowlReached;
        _feedGameMover.TargetReached -= OnTargetReached;
    }

    private void OnBowlReached()
    {
        _feedGameMover.enabled = true;
    }

    private void OnTargetReached()
    {
        _particle.PlayWin();
        _scoreCalculate.StopCalculate();
        _gameOverScreen.ShowWin();
    }
}
