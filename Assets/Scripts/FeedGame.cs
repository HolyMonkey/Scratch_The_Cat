using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedGame : MonoBehaviour
{
    [SerializeField] private AnimalPrefabs _animalPrefabs;
    [SerializeField] private Transform _animalPlace;

    [SerializeField] private Bowl _bowl;
    [SerializeField] private FoodBox _foodBox;
    [SerializeField] private Transform _animalWaypoint;
    [SerializeField] private ProgressSlider _progressSlider;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private CurrentScoreView _currentScoreView;

    [SerializeField] private ParticleSystem[] _afterGameParticles;

    private Animal _animal;

    private float _totalTime;
    private int _maxScore;
    private int _score;
    private int _coins;

    private void Awake()
    {
        var animal = Instantiate(_animalPrefabs.TryGetAnimal(PlayerPrefs.GetInt("CurrentAnimal")), _animalPlace);
        _animal = animal;
        _animal.GetComponent<Collider>().enabled = false;
        _maxScore = 1000;
    }

    private void OnEnable()
    {
        _bowl.CollisionHandler.FillBowl += OnFillBowl;
    }

    private void OnDisable()
    {
        _bowl.CollisionHandler.FillBowl -= OnFillBowl;
    }

    private void Update()
    {
        _totalTime += Time.deltaTime;
        _maxScore = 1000 - Mathf.RoundToInt(_totalTime) * 10;
        _score = Mathf.RoundToInt(_maxScore * _progressSlider.Value);
        _currentScoreView.ChangeScore(_score);

        if (Input.GetMouseButtonDown(0))
            _foodBox.DropingFood(true);

        if (Input.GetMouseButtonUp(0))
            _foodBox.DropingFood(false);

        if(_progressSlider.Value == 1)
        {
            _foodBox.gameObject.SetActive(false);
            _animal.Mover.SetTarget(_animalWaypoint.position);

            if (_animal.transform.position == _animalWaypoint.position)
            {
                foreach (var particle in _afterGameParticles)
                {
                    if (particle.isPlaying == false)
                        particle.Play();
                }
                
                _coins = _score / 10;
                _gameOverScreen.Enable();
                _gameOverScreen.Init(_score, _coins);
                this.enabled = false;
            }
        }
    }

    private void OnFillBowl()
    {
        _progressSlider.ChangeValue(1f * Time.deltaTime);
        _bowl.Fill(_progressSlider.Value);
    }
}
