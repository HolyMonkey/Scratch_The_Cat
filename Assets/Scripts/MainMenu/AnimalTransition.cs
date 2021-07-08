using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public abstract class AnimalTransition : MonoBehaviour
    {
        [SerializeField] private AnimalState _nextState;
        private AnimalState _prevoiusState;

        protected Animal CurrentAnimal { get; private set; }
        protected AnimalStateMachine StateMachine { get; private set; }

        protected void ChangeState()
        {
            _prevoiusState.Exit();
            _nextState.Enter(CurrentAnimal, StateMachine);
        }

        public virtual void Enter(AnimalState prevoiusState)
        {
            _prevoiusState = prevoiusState;
            CurrentAnimal = prevoiusState.CurrentAnimal;
            StateMachine = prevoiusState.StateMachine;
            enabled = true;
        }

        public virtual void Exit()
        {
            enabled = false;
        }

        public void ForceChangeState()
        {
            ChangeState();
        }

    }   
}
