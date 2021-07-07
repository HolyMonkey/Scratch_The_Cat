using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFolder : MonoBehaviour
{
    private float _score;

    public void SetScore(float score)
    {
        _score = score;
    }

    public float GetScore()
    {
        return _score;
    }
}
