using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class AnimalInit : MonoBehaviour
    {
        [SerializeField] private AnimalsData _animalsData;
        [SerializeField] private AnimalStateMachine _animalStateMachine;
        [SerializeField] private PlayerSpawner _playerSpawner;
        private Animal _animal;

        private void OnEnable()
        {
            _animalsData.AnimalChoyse += OnAnimalChoyse;
        }

        private void OnDisable()
        {
            _animalsData.AnimalChoyse -= OnAnimalChoyse;
        }

        private void OnAnimalChoyse(Animal animal)
        {
            _animal = _playerSpawner.Spawn(animal);
            _animal.Collider.isTrigger = true;
            _animalStateMachine.Init(_animal);
        }
    }   
}
