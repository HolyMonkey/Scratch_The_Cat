using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstInputLooker : MonoBehaviour
{
    [SerializeField] private ScoreCalculate _scoreCalculate;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _scoreCalculate.StartCalculate();
            enabled = false;
        }
    }
}
