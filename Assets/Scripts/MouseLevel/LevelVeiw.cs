using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class LevelVeiw : MonoBehaviour
    {
        [SerializeField] private SliderShake _sliderShake;
        [SerializeField] private CurrentScoreView _currentScoreView;
        [SerializeField] private ProgressSlider _progressSlider;
        [SerializeField] private MouseLevelParticle _mouseLevelParticle;

        public void SetSliderMaxValue(float value)
        {
            _progressSlider.SetMaxValue(value);
        }

        public void ShowFail()
        {
            _mouseLevelParticle.PlayFail();
        }

        public void ShowSuccess()
        {
            _mouseLevelParticle.PlaySuccess();
        }

        public void ShowWin()
        {
            _mouseLevelParticle.PlayWin();
        }

        public void ShowNewValue(float value)
        {
            float score = value;
            int wholeScore = (int) score;
            _progressSlider.SetValue(score);
            _currentScoreView.SetScore(wholeScore);
            _sliderShake.Shake();
        }
    }
}

