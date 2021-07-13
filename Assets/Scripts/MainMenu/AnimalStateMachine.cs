using UnityEngine;

namespace MainMenu
{
    public class AnimalStateMachine : MonoBehaviour
    {
        [SerializeField] private AnimalState[] _animalStates;

        [SerializeField] private AnimalTransition[] _animalTransitions;
        [SerializeField] private AnimalState _firstState;
        [SerializeField] private MainMenuPosiblePositionToMove _posiblePosition;
        public Animal CurrentAnimal { get; private set; }

        public MainMenuPosiblePositionToMove PosiblePosition => _posiblePosition;

        public void Init(Animal animal)
        {
            CurrentAnimal = animal;
            _firstState.Enter(CurrentAnimal, this);
        }

        public void Stop()
        {
            foreach (var state in _animalStates)
            {
                state.enabled = false;
            }

            foreach (var transition in _animalTransitions)
            {
                transition.enabled = false;
            }
        }
    }   
}
