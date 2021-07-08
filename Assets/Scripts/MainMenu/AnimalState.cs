using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public abstract class AnimalState : MonoBehaviour
    {
        [SerializeField] protected AnimalTransition[] AnimalTransitions;

        public Animal CurrentAnimal { get; private set;}
        public AnimalStateMachine StateMachine { get; private set; }


        public void Init(Animal animal)
        {
            CurrentAnimal = animal;
        }

        public virtual void Enter(Animal animal, AnimalStateMachine animalStateMachine)
        {
            CurrentAnimal = animal;
            StateMachine = animalStateMachine;
            
            enabled = true;
            foreach (var transition in AnimalTransitions)
            {
                transition.Enter(this);
            }
        }

        public virtual void Exit()
        {
            enabled = false;
            foreach (var transition in AnimalTransitions)
            {
                transition.Exit();
            }
        }

        protected virtual void ForceExit()
        {
            AnimalTransitions[Random.Range(0, AnimalTransitions.Length)].ForceChangeState();
        }
    }
}

