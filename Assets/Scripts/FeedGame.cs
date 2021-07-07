using System;
using System.Collections;
using System.Collections.Generic;
using MouseLevel;
using UnityEngine;

public class FeedGame : MonoBehaviour
{
    [SerializeField] private ScoreMediator _scoreMediator;
    [SerializeField] private ScoreCalculate _scoreCalculate;
    [SerializeField] private Bowl _bowl;
    [SerializeField] private FoodBox _foodBox;
    [SerializeField] private GameOverScreen _gameOverScreen;

    [SerializeField] private Lostzone _lostzone1;
    [SerializeField] private Lostzone _lostzone2;


    [SerializeField] private float _maxFillBowlValue;

    private float _totalTime;
    private int _maxScore;
    private int _score;
    private int _coins;
    private float _fillBowlValue;

    public event Action BowlReached;

    private void OnEnable()
    {
        _bowl.CollisionHandler.FillBowl += OnFillBowl;
        _lostzone1.CollisionHandler.LostFeed += OnPastBowl;
        _lostzone2.CollisionHandler.LostFeed += OnPastBowl;
    }

    private void OnDisable()
    {
        _bowl.CollisionHandler.FillBowl -= OnFillBowl;
        _lostzone1.CollisionHandler.LostFeed -= OnPastBowl;
        _lostzone2.CollisionHandler.LostFeed -= OnPastBowl;
    }

    private void Awake()
    {
        _scoreMediator.SetMaxValue(_maxFillBowlValue);
    }

    private void Update()
    {
        _totalTime += Time.deltaTime;
        _maxScore = 1000 - Mathf.RoundToInt(_totalTime) * 10;

        if (Input.GetMouseButtonDown(0))
            _foodBox.DropingFood(true);

        if (Input.GetMouseButtonUp(0))
            _foodBox.DropingFood(false);

        if(_fillBowlValue >= _maxFillBowlValue)
        {
            BowlReached?.Invoke();
            _foodBox.gameObject.SetActive(false);
            this.enabled = false;
        }

        if (_maxScore <= 0)
        {
            _scoreCalculate.StopCalculate();
            _gameOverScreen.ShowLose();
            this.enabled = false;
        }
    }
    
    private void OnFillBowl()
    {
        _fillBowlValue += Time.deltaTime; 
        SetView();
        _bowl.Fill(_fillBowlValue/_maxFillBowlValue);
    }

    private void OnPastBowl()
    {
        _fillBowlValue -= Time.deltaTime;
        SetView();
        _bowl.Fill(_fillBowlValue/_maxFillBowlValue);
    }

    private void SetView()
    {
        if (_fillBowlValue < 0)
        {
            _fillBowlValue = 0;
        }
        _scoreMediator.SetSliderValue(_fillBowlValue);
        int value = (int) (_fillBowlValue * 100);
        _scoreMediator.ShowScoreValue(value);
    }
}
