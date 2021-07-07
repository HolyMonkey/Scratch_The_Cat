using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RunnerGame : MonoBehaviour
{
    [SerializeField] private AnimalPrefabs _animalPrefabs;
    [SerializeField] private Transform _animalPlace;

    [SerializeField] private GameOverScreen _gameoverScreen;
    [SerializeField] private Transform _animalTarget;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private Obstacle[] _obstacles;
    [SerializeField] private CoinsFolder _coinsFolder;
    [SerializeField] private ScoreMediator _scoreMediator;
    [SerializeField] private ScoreCalculate _scoreCalculate;
    [SerializeField] private RunnerGameMover _runnerGameMover;

    private Animal _animal;
    private float _totalTime;
    private int _score;
    private int _coins;
    private int _maxScore;
    private int _currentMaxScore;
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

    private void Awake()
    {
        var animal = Instantiate(_animalPrefabs.TryGetAnimal(PlayerPrefs.GetInt("CurrentAnimal")), _animalPlace);
        _animal = animal;
        _animal.Collider.direction = 1;
        _cameraMover.SetTarget(_animal);
        float distance = Vector3.Distance(_animalTarget.transform.position, _animal.transform.position);
        _scoreMediator.SetMaxValue(distance);
        
    }

    private void Start()
    {
        _runnerGameMover.Init(_animal.Movable, _animalTarget.position);
        _runnerGameMover.enabled = true;
        _animal.Animator.Play(AnimatorAnimalController.States.ResizingSpin);
        _maxScore = 1000;
        _currentMaxScore = _maxScore;
    }

    private void Update()
    {
        _totalTime += Time.deltaTime;
        _maxScore = _currentMaxScore - Mathf.RoundToInt(_totalTime) * 10;
        _score = Mathf.RoundToInt(_maxScore * _scoreMediator.GetPersentOfMaxScore());
        _scoreMediator.ShowScoreValue(_score);

        if (Input.GetMouseButtonDown(0))
        {
            _animal.Animator.SetBool(AnimatorAnimalController.Params.IsSpin, false);
            _animal.Collider.direction = 0;
        }

        float value = _maxDistance - Vector3.Distance(_animalTarget.position, _animal.transform.position);
        _scoreMediator.SetSliderValue(value);

        if (Input.GetMouseButtonUp(0))
        {
            _animal.Animator.SetBool(AnimatorAnimalController.Params.IsSpin, true);
            _animal.Collider.direction = 1;
        }


        if (_scoreMediator.GetPersentOfMaxScore() > 1)
        {
            _scoreCalculate.StopCalculate();
            _gameoverScreen.ShowWin();
            this.enabled = false;
        }
    }

    private void OnCollided()
    {
        _scoreMediator.SetFailScore(50);
        _scoreCalculate.SetPenalty(50);
    }
}
