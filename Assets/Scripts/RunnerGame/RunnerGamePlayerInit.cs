using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class RunnerGamePlayerInit : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private RunnerGameMover _runnerGameMover;
        [SerializeField] private CameraMover _cameraMover;
        [SerializeField] private Transform _targert;
        [SerializeField] private RunnerGame _runnerGame;
        [SerializeField] private RunnerGameSliderValue _runnerGameSliderValue;

        private void Awake()
        {
            Animal animal = _playerSpawner.Spawn();
            animal.Collider.direction = 1;
            _runnerGame.SetAnimal(animal);
            _runnerGame.enabled = true;
            _runnerGameMover.Init(animal.Movable, _targert.position);
            _runnerGameMover.enabled = true;
            _runnerGameSliderValue.SetPlayerTransform(animal.transform);
            _runnerGameSliderValue.enabled = true;
            _cameraMover.SetTarget(animal);
            _cameraMover.enabled = true;
        }
    }
}