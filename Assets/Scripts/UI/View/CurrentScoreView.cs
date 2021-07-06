using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CurrentScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreView;
    [SerializeField] private int _scoreStepRedEffect;

    private int _score;
    private int _previousScore;

    private void Start()
    {
        _scoreView.text = 0.ToString();
    }

    private void Update()
    {
        if(_scoreView.color == Color.red)
            _scoreView.DOColor(Color.white, 0.1f);
    }
    
    public void SetScore(int score)
    {
        _score = score;
        _scoreView.text = _score.ToString();

        if (Mathf.Abs(_score - _previousScore) > _scoreStepRedEffect)
        {
            _scoreView.DOColor(Color.red, 0.1f);
        }

        _previousScore = score;
    }
}
