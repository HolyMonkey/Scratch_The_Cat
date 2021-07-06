using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGame : MonoBehaviour
{
    [SerializeField] private AnimalPrefabs _animalPrefabs;
    [SerializeField] private Transform _animalPlace;

    [SerializeField] GameOverScreen _gameOverScreen;
    [SerializeField] private ProgressSlider _progressSlider;
    [SerializeField] private ParticleSystem[] _inGameSuccessParticles;
    [SerializeField] private ParticleSystem[] _inGameFailParticles;
    [SerializeField] private ParticleSystem[] _afterGameParticles;
    [SerializeField] private Mouse _mouse;
    [SerializeField] private int _catchesForWin;
    [SerializeField] private CurrentScoreView _currentScoreView;

    private Animal _animal;

    private int _currentCatches;
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

    private void Update()
    {
        _totalTime += Time.deltaTime;
        _maxScore = 1000 - Mathf.RoundToInt(_totalTime) * 10;
        _currentScoreView.SetScore(_score);

        //_animal._MoverOld.SetTarget(_mouse.transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = Vector3.Distance(_mouse.transform.position, _animal.transform.position);

            if (distance < 3)
            {
                if (distance > 1)
                {
                    _currentCatches++;
                    _animal.Particles.FeatherExplosion.Play();
                    _animal.Animator.Play(AnimatorAnimalController.States.Click);
                    _mouse.Mover.Catch();

                    foreach (var particle in _inGameSuccessParticles)
                    {
                        if (particle.isPlaying == false)
                        {
                            particle.Play();
                            break;
                        }
                    }
                }
                else if (distance < 1)
                {
                    foreach (var particle in _inGameFailParticles)
                    {
                        if (particle.isPlaying == false)
                        {
                            particle.Play();
                            break;
                        }
                    }
                }
            }

        }

        /*if(_progressSlider.Value == 1)
        {
            _coins = _score / 10;
            _gameOverScreen.Enable();
            _gameOverScreen.Init(_score, _coins);

            if (_animal != null)
            {
                Destroy(_animal.gameObject);
                Destroy(_mouse.gameObject);
            }

            foreach (var particle in _afterGameParticles)
            {
                if (particle.isPlaying == false)
                    particle.Play();
            }

            this.enabled = false;
        }*/
    }
}
