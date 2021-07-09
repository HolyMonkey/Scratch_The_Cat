using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuConditionView : MonoBehaviour
{
    [SerializeField] private PlayerConditionViewMediator _playerConditionViewMediator;

    private void Start()
    {
        _playerConditionViewMediator.Show();
    }
}
