using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerGame : MonoBehaviour
{
    [SerializeField] private AnimalPrefabs _animalPrefabs;
    [SerializeField] private Transform _animalPlace;

    [SerializeField] private GameOverScreen _gameoverScreen;
    [SerializeField] private ProgressSlider _slider;
    [SerializeField] private Transform _animalTarget;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private CurrentScoreView _currentScoreView;
    [SerializeField] private Obstacle[] _obstacles;

    private Animal _animal;
    private float _totalTime;
    private int _score;
    private int _coins;
    private int _maxScore;
    private int _currentMaxScore;

    private void OnEnable ()
    {
        foreach (var obstacle in _obstacles)
        {
            obstacle.Collided += OnCollided;
        }
    }

    private void OnDisable ()
    {
        foreach (var obstacle in _obstacles)
        {
            obstacle.Collided -= OnCollided;
        }
    }

    private void Awake ()
    {
        var animal = Instantiate(_animalPrefabs.TryGetAnimal(PlayerPrefs.GetInt("CurrentAnimal")), _animalPlace);
        _animal = animal;
        _animal.Collider.direction = 1;
        _cameraMover.SetTarget(_animal);
    }

    private void Start ()
    {
        _animal.Mover.SetTarget(_animalTarget.position);
        _animal.Animator.Play(AnimatorAnimalController.States.ResizingSpin);
        _maxScore = 1000;
        _currentMaxScore = _maxScore;
    }

    private void Update ()
    {
        _totalTime += Time.deltaTime;
        _maxScore = _currentMaxScore - Mathf.RoundToInt(_totalTime) * 10;
        _score = Mathf.RoundToInt(_maxScore * _slider.Value);
        _currentScoreView.ChangeScore(_score);

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

        _slider.ChangeValue(_animalTarget.position.x, _animal.transform.position.x, false);

        if (_slider.Value == 1)
        {
            _coins = _score / 10;

            _gameoverScreen.Enable();
            _gameoverScreen.Init(_score, _coins, -0.32f, 0.27f, -0.2f, 0.14f);
            this.enabled = false;
        }
    }

    private void OnCollided ()
    {
        _currentScoreView.DecreaseScore(50);
        _currentMaxScore -= 50;
    }
}
