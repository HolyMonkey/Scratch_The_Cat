using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private float _elapsedTime = 0;
    private int _elapsedSeconds = 0;

    private void Update ()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= 1)
        {
            _elapsedTime = 0;
            _elapsedSeconds++;
            _text.text = _elapsedSeconds.ToString();
        }
    }
}
