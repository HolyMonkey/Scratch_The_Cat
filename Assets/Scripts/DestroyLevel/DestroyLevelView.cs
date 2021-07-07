using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DestroyLevel
{
    public class DestroyLevelView : LevelView
    {
        
        public override void ShowNewValue(float value)
        {
            int wholeValue = (int) value;
            ProgressSlider.SetValue(value);
            CurrentScoreView.SetScore(wholeValue);
            SliderShake.Shake();
        }
    } 
}

