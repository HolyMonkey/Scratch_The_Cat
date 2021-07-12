using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMediator : MonoBehaviour
{
    [SerializeField] private ProgressSlider _progressSlider;
    [SerializeField] private CurrentScoreView _currentScoreView;
    [SerializeField] private SliderShake _sliderShake;
    
    private float _maxScore;
    private float _currentScore;
    
    
    public void SetMaxValue(float score)
    {
        _progressSlider.SetMaxValue(score);
        _maxScore = score;
    }

    public void SetSliderValue(float score)
    {
        _currentScore = score;
        _progressSlider.SetValue(score);
    }

    public void ShowScoreValue(int score)
    {
        _currentScoreView.SetScore(score);
    }

    public void SetFailScore(int score)
    {
        _currentScoreView.SetScore(score);
        _sliderShake.Shake();
    }

    public float GetPersentOfMaxScore()
    {
        return _currentScore / _maxScore;
    }

    public void Hide()
    {
        _progressSlider.gameObject.SetActive(false);
        _currentScoreView.gameObject.SetActive(false);
    }
}
