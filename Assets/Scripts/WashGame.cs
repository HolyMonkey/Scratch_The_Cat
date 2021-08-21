using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using WashLevel;

public class WashGame : MonoBehaviour
{
    [SerializeField] private ItemInHand _itemInHand;
    [SerializeField] private List<ItemView> _itemViews;
    [SerializeField] private WashingState[] _washingStates;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerSpawner _playerSpawner;

    private WashingState _currentState;
    private int _currentStateNumber;

    private void Awake()
    {
        Animal animal = _playerSpawner.Spawn();
        _currentStateNumber = 0;
        _currentState = _washingStates[_currentStateNumber];
    }

    private void OnEnable()
    {
        _inputHandler.MouseDraging += Washing;
        _inputHandler.UnClicked += EndWashing;
        foreach (var washingState in _washingStates)
        {
            washingState.StateComplited += EnterNextState;
        }
    }

    private void OnDisable()
    {
        _inputHandler.MouseDraging -= Washing;
        _inputHandler.UnClicked -= EndWashing;
        foreach (var washingState in _washingStates)
        {
            washingState.StateComplited -= EnterNextState;
        }
    }
    
    private void Washing()
    {
        if (_itemInHand.GetItemInHand() == _currentState.ItemType)
        {
            _currentState.Wash();
            if (_currentState.AudioSource.isPlaying == false && _currentState.IsWashing)
            {
                _currentState.AudioSource.Play();
            }
        }
    }

    private void EndWashing()
    {
        _currentState.AudioSource.Pause();
    }

    private void EnterNextState()
    {
        _currentState.AudioSource.Stop();
        _itemInHand.SetNoneItem();

        Destroy(_itemViews[_currentStateNumber].gameObject);
        _currentStateNumber++;
        
        if (_currentStateNumber >= _washingStates.Length)
        {
            enabled = false;
            return;
        }
        
        _currentState = _washingStates[_currentStateNumber];
        _currentState.Enter();
    }
}