using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DestroyLevel
{
    public class PlayerInit : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private JoystickMover _joystickMover;
        [SerializeField] private CameraMover _cameraMover;

        private void Awake()
        {
            Animal animal = _playerSpawner.Spawn();
            _joystickMover.Init(animal.Movable, animal.Animator);
            _cameraMover.SetTarget(animal);
            _cameraMover.enabled = true;
            _joystickMover.enabled = true;
        }
    }
}
