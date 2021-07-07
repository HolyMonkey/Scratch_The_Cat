using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class MouseLevelVeiw : LevelView
    {
        public override void ShowNewValue(float value)
        {
            float score = value;
            int wholeScore = (int) score;
            ProgressSlider.SetValue(score);
            CurrentScoreView.SetScore(wholeScore);
            SliderShake.Shake();
        }
    }
}