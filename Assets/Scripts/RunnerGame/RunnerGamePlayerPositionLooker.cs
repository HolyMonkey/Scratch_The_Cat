using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class RunnerGamePlayerPositionLooker : MonoBehaviour
    {
        [SerializeField] private RunnerGameMover _runnerGameMover;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private RunnerGame _runnerGame;
        [SerializeField] private ScoreCalculate _scoreCalculate;

        [SerializeField] private Particle _particle;

        private void OnEnable()
        {
            _runnerGameMover.PositionReached += OnPositionReached;
        }

        private void OnDisable()
        {
            _runnerGameMover.PositionReached -= OnPositionReached;
        }

        private void OnPositionReached()
        {
            _scoreCalculate.StopCalculate();
            _runnerGame.enabled = false;
            _particle.PlayWin();
            _gameOverScreen.ShowWin();
        }
    }   
}
