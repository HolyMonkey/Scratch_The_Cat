using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WashGame : MonoBehaviour
{
    [SerializeField] private AnimalPrefabs _animalPrefabs;
    [SerializeField] private Transform _animalPlace;

    [SerializeField] private ItemView[] _views;
    [SerializeField] private Transform _bubblesContainer;
    [SerializeField] private Bubbles _bubblesPrefab;
    [SerializeField] private ProgressSlider _progressSlider;
    [SerializeField] private GameOverScreen _gameoverScreen;
    [SerializeField] private CurrentScoreView _currentScoreView;

    public int Phase => _phase;

    private Animal _animal;
    private int _phase;
    private float _totalTime;
    private int _maxScore;
    private int _score;
    private int _coins;

    private Vector2 _startPosition;
    private Vector2 _currentPosition;

    private void Awake ()
    {
        var animal = Instantiate(_animalPrefabs.TryGetAnimal(PlayerPrefs.GetInt("CurrentAnimal")), _animalPlace);
        _animal = animal;
        _maxScore = 1000;
    }

    private void OnEnable ()
    {
        foreach (var view in _views)
        {
            view.ButtonClicked += OnButtonClicked;
        }
    }

    private void OnDisable ()
    {
        foreach (var view in _views)
        {
            view.ButtonClicked -= OnButtonClicked;
        }
    }

    private void Update ()
    {
        _totalTime += Time.deltaTime;
        _maxScore = 1000 - Mathf.RoundToInt(_totalTime) * 10;
        _score = Mathf.RoundToInt(_maxScore * _progressSlider.Value);
        _currentScoreView.ChangeScore(_score);

        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Animal animal))
                {

                    if (_phase == 1)
                    {
                        var bubbles = Instantiate(_bubblesPrefab, Input.mousePosition, Quaternion.identity, _bubblesContainer);
                        bubbles.Init(this);
                        _progressSlider.ChangeValue(0.0055f, false);
                    }

                    if (_phase == 2)
                    {
                        _currentPosition = Input.mousePosition;
                        if (Vector2.Distance(_startPosition, _currentPosition) > 5)
                        {
                            _startPosition = Input.mousePosition;
                            _progressSlider.ChangeValue(0.0017f, false);
                        }

                        if (_bubblesContainer.childCount == 0)
                        {
                            _progressSlider.SetValue(0.67f);
                        }
                    }

                    if (_phase == 3)
                    {
                        _currentPosition = Input.mousePosition;
                        if (Vector2.Distance(_startPosition, _currentPosition) > 5)
                        {
                            _startPosition = Input.mousePosition;
                            _progressSlider.ChangeValue(0.002f, false);
                        }
                    }
                }
            }
        }

        if (_progressSlider.Value < 0.66f && _phase == 3)
        {
            _phase = 0;
        }

        if (_progressSlider.Value < 0.33f && _phase == 2)
        {
            _phase = 0;
        }

        if (_progressSlider.Value > 0.33f && _phase == 1)
        {
            _phase = 0;
            Destroy(_views[0].gameObject);
            _animal.Particles.HeartPoof.Play();
        }

        if (_progressSlider.Value > 0.66f && _phase == 2)
        {
            _phase = 0;
            Destroy(_views[1].gameObject);
            _animal.Particles.HeartPoof.Play();

            if (_bubblesContainer.childCount > 0)
            {
                for (int i = 0; i < _bubblesContainer.childCount; i++)
                {
                    Destroy(_bubblesContainer.GetChild(i).gameObject);
                }
            }
        }

        if (_progressSlider.Value == 1)
        {
            _coins = _score / 10;

            PlayerPrefs.SetInt("CoinsForLastLevel", _coins);

            _gameoverScreen.Enable();
            _gameoverScreen.Init(_score, _coins, -0.3f, 0.22f, 0.69f, -0.27f);
            this.enabled = false;
        }
    }

    private void OnButtonClicked (int phase)
    {
        SetPhase(phase);
    }

    private void SetPhase (int phase)
    {
        _phase = phase;
    }

    /*private void IsMouseOverBubbles()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        _progressSlider.ChangeValue(Time.deltaTime / 1.5f, false);

        for (int i = 0; i < raycastResultList.Count; i++)
        {
            if(raycastResultList[i].gameObject.TryGetComponent(out Bubbles bubbles))
            {
                raycastResultList.RemoveAt(i);
                Destroy(bubbles.gameObject);
                _progressSlider.ChangeValue(Time.deltaTime / 2, false);
                i--;
            }
        }
    }*/
}
