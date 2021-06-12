using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGame : MonoBehaviour
{
    [SerializeField] private AnimalPrefabs _animalPrefabs;
    [SerializeField] private Transform _animalPlace;
    [SerializeField] private CameraMover _cameraMover;

    [SerializeField] private Prop[] _props;
    [SerializeField] private ParticleSystem[] _inGameParticles;
    [SerializeField] private ParticleSystem[] _afterGameParticles;
    [SerializeField] private ProgressSlider _progressSlider;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private CurrentScoreView _currentScoreView;

    private Animal _animal;
    private Animator _animalAnimator;
    private AnimalParticles _animalParticles;
    
    private int _propsLeft;
    private float _totalTime;
    private int _maxScore;
    private int _score;
    private int _coins;

    private void Awake()
    {
        var animal = Instantiate(_animalPrefabs.TryGetAnimal(PlayerPrefs.GetInt("CurrentAnimal")), _animalPlace);
        _animal = animal;
        _animal.Mover.EnableJoystickMode(_joystick);
        _cameraMover.SetTarget(_animal);
    }

    private void Start()
    {
        _propsLeft = Convert.ToInt32((_props.Length / 1.5) / 1);
        _maxScore = 1000;
    }

    private void OnEnable()
    {
        foreach (var prop in _props)
        {
            prop.Destroyed += OnPropDestroyed;
        }
    }

    private void Update()
    {
        _totalTime += Time.deltaTime;
        _maxScore = 1000 - Mathf.RoundToInt(_totalTime) * 10;
        _score = Mathf.RoundToInt(_maxScore * _progressSlider.Value);
        _currentScoreView.ChangeScore(_score);

        if (_progressSlider.Value == 1)
        {
            foreach (var particle in _afterGameParticles)
            {
                if (particle.isPlaying == false)
                    particle.Play();
            }

            if (_animal != null)
                Destroy(_animal.gameObject);

            _coins = _score / 10;
            _gameOverScreen.Enable();
            _gameOverScreen.Init(_score, _coins);
            _joystick.gameObject.SetActive(false);
            _progressSlider.gameObject.SetActive(false);
            this.enabled = false;
        }
    }

    private void OnPropDestroyed()
    {
        foreach (var particle in _inGameParticles)
        {
            if (particle.isPlaying == false)
            {
                particle.Play();
                break;
            }
        }

        _propsLeft--;
        _progressSlider.ChangeValue(Convert.ToInt32((_props.Length / 1.5) / 1), Convert.ToInt32((_props.Length / 1.5) / 1) - _propsLeft);
    }
}
