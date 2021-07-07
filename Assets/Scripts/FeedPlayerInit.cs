using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedPlayerInit : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private FeedGameMover _feedGameMover;

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        Animal animal = _playerSpawner.Spawn();
        _feedGameMover.Init(animal.Movable, animal.Animator);
    }
}
