using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetGame : MonoBehaviour
{
    [SerializeField] private AnimalPrefabs _animalPrefabs;
    [SerializeField] private Transform _animalPlace;

    [SerializeField] private HappinesSlider _slider;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private float _distance;
    [SerializeField] private ParticleSystem[] _afterGameParticles;
    [SerializeField] private CurrentScoreView _currentScoreView;

    private Animal _animal;
    private Animator _animalAnimator;
    private AnimalParticles _animalParticles;

    private int _score;
    private int _coins;
    private float _totalTime;
    private int _maxScore;

    private float _timeAfterTouch;
    private Vector2 _startPosition;
    private Vector2 _currentPosition;

    private int _phase;

    private void Awake()
    {
        var animal = Instantiate(_animalPrefabs.TryGetAnimal(PlayerPrefs.GetInt("CurrentAnimal")), _animalPlace);
        _animal = animal;
        _animalAnimator = _animal.Animator;
        _animalParticles = _animal.Particles;
        //_animal.GetComponent<Collider>().enabled = false;
        _maxScore = 1000;
    }

    private void Update()
    {
        _totalTime += Time.deltaTime;
        _maxScore = 1000 - Mathf.RoundToInt(_totalTime) * 10;
        _score = Mathf.RoundToInt(_maxScore * _slider.Value);
        _currentScoreView.SetScore(_score);

        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            _timeAfterTouch += Time.deltaTime;
            _currentPosition = Input.mousePosition;

            if(Vector2.Distance(_startPosition, _currentPosition) > _distance)
            {
                _startPosition = _currentPosition;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100f))
                {
                    if (hit.collider.TryGetComponent(out Animal zone))
                    {
                        Pet();
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(_timeAfterTouch < 0.2f)
            {
                _animalParticles.EmojiAngry2.Play();
                _animalAnimator.SetTrigger(AnimatorAnimalController.Params.Clicked);
                _slider.ChangeValue(-1f);
                _slider.Shake();
            }

            _timeAfterTouch = 0;
            _animalParticles.EmojiAngry.Stop();
            _animalParticles.EmojiHeart.Stop();
            _animalAnimator.SetBool(AnimatorAnimalController.Params.IsHappy, false);
            _animalAnimator.SetBool(AnimatorAnimalController.Params.IsAngry, false);
        }

        if(_slider.Value >= 0.5f && _phase == 0)
        {
            NextPhase();
        }

        if (_slider.Value == 1 && _phase == 1)
        {
            Complete();
        }
    }

    private void Pet()
    {
        float value;
        string animationState;
        value = Time.deltaTime * 3f;
        animationState = AnimatorAnimalController.States.Clicked;

        if (_animalParticles.EmojiHeart.isPlaying == false)
        {
            _animalParticles.EmojiHeart.Play();
            _animalParticles.EmojiAngry.Stop();
        }

        _slider.ChangeValue(value);

        if (IsAnimationPlaying(_animalAnimator, AnimatorAnimalController.States.Idle) == true)
        {
            _animalAnimator.Play(animationState);
        }
    }

    private void NextPhase()
    {
        _phase++;
        _animalAnimator.Play(AnimatorAnimalController.Params.Spin);
        _animalParticles.HeartPoof.Play();
        _animal.transform.Rotate(0, -90, 0);
    }

    private void Complete()
    {
        this.enabled = false;
        _phase++;
        _animalAnimator.Play(AnimatorAnimalController.States.Bounce);
        _animal.transform.Rotate(0, 90, 0);
        DisableParticles();
        _slider.gameObject.SetActive(false);

        _coins = _score / 10;

        foreach (var particle in _afterGameParticles)
        {
            if (particle.isPlaying == false)
                particle.Play();
        }

    }

    public static bool IsAnimationPlaying(Animator animator, string animationName)
    {
        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }

    private void DisableParticles()
    {
        _animalParticles.EmojiAngry.gameObject.SetActive(false);
        _animalParticles.EmojiAngry2.gameObject.SetActive(false);
        _animalParticles.EmojiHeart.gameObject.SetActive(false);
    }
}
