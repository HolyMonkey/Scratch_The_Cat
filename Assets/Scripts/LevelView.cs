using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelView : MonoBehaviour
{
    [SerializeField] private SliderShake _sliderShake;
    [SerializeField] private CurrentScoreView _currentScoreView;
    [SerializeField] private ProgressSlider _progressSlider;
    [SerializeField] private LevelParticle _levelParticle;

    protected CurrentScoreView CurrentScoreView => _currentScoreView;
    protected ProgressSlider ProgressSlider => _progressSlider;
    protected SliderShake SliderShake => _sliderShake;

    public virtual void SetSliderMaxValue(float value)
    {
        _progressSlider.SetMaxValue(value);
    }

    public void ShowFail()
    {
        _levelParticle.PlayFail();
    }

    public void ShowSuccess()
    {
        _levelParticle.PlaySuccess();
    }

    public void ShowWin()
    {
        _levelParticle.PlayWin();
    }

    public abstract void ShowNewValue(float value);
}
