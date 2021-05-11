using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private CoinsCounter _coinsCounter;

    public event UnityAction<int> ScoreChanged;

    private int _currentScore;

    public int TotalScore { get; set;}

    private void Update()
    {
        if(_currentScore < TotalScore)
        {
            _currentScore += 10;
            ScoreChanged?.Invoke(_currentScore);
        }
        else if(_coinsCounter.enabled == false)
        {
            _coinsCounter.enabled = true;
        }
    }
}
