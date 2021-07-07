using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class MousePlayerInit : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private AnimalChase _animalChase;
        [SerializeField] private Mouse _mouse;

        private void Awake()
        {
            Animal animal = _playerSpawner.Spawn();
            _animalChase.Init(animal.Movable, animal.Animator);
            _animalChase.SetTarget(_mouse.transform);
            _animalChase.enabled = true;
            if (animal.TryGetComponent(out Collider collider))
            {
                collider.isTrigger = true;
            }
        }
    }
}