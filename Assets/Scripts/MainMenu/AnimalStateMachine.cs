using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class AnimalStateMachine : MonoBehaviour
    {
        [SerializeField] private AnimalState _firstState;
        [SerializeField] private MainMenuPosiblePositionToMove _posiblePosition;
        public Animal CurrentAnimal { get; private set; }

        public MainMenuPosiblePositionToMove PosiblePosition => _posiblePosition;

        public void Init(Animal animal)
        {
            CurrentAnimal = animal;
            _firstState.Enter(CurrentAnimal, this);
        }

    }   
}
