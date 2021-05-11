using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CurrentScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreView;

    private int _score;

    private void Update()
    {
        if(_scoreView.color == Color.red)
            _scoreView.DOColor(Color.white, 0.1f);

            _scoreView.text = _score.ToString();
    }

    public void DecreaseScore(int value)
    {
        _scoreView.DOColor(Color.red, 0.1f);
        _score -= value;
    }

    public void ChangeScore(int score)
    {
        _score = score;
    }
}
