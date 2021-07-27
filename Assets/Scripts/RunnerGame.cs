using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RunnerGame : MonoBehaviour
{
    [SerializeField] private Obstacle[] _obstacles;
    [SerializeField] private ScoreMediator _scoreMediator;
    [SerializeField] private ScoreCalculate _scoreCalculate;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private RunnerGameMover _mover;

    private Animal _animal;
    private float _totalTime;
    private int _maxScore;
    private float _maxDistance;

    private void OnEnable()
    {
        foreach (var obstacle in _obstacles)
        {
            obstacle.Collided += OnCollided;
        }
    }

    private void OnDisable()
    {
        foreach (var obstacle in _obstacles)
        {
            obstacle.Collided -= OnCollided;
        }
    }

    private void Start()
    {
        _animal.Animator.Play(AnimatorAnimalController.States.ResizingSpin);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animal.Animator.SetBool(AnimatorAnimalController.Params.IsSpin, false);
            _animal.Collider.direction = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animal.Animator.SetBool(AnimatorAnimalController.Params.IsSpin, true);
            _animal.Collider.direction = 1;
        }
    }

    private void OnCollided()
    {
        _gameOverScreen.ShowLose();
        enabled = false;
        _mover.Stop();
    }

    public void SetAnimal(Animal animal)
    {
        _animal = animal;
    }
}
