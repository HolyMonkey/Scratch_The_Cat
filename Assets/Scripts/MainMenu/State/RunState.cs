using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class RunState : AnimalState
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _targetPositionDeltaToReach;
        private Movable _movable;
        private Transform _target;
        
        private void OnEnable()
        {
            _target = StateMachine.PosiblePosition.GetRandomPosition();
            _movable = CurrentAnimal.Movable;
            _movable.SetSpeed(_speed);
            CurrentAnimal.Animator.SetBool(AnimatorAnimalController.Params.IsRun, true);
        }

        private void OnDisable()
        {
            CurrentAnimal.Animator.SetBool(AnimatorAnimalController.Params.IsRun, false);
        }

        private void Update()
        {
            Vector3 direction = _target.position;
            direction.y = _movable.transform.position.y;
            direction -= _movable.transform.position;
            _movable.Move(direction.normalized);

            if (direction.magnitude < _targetPositionDeltaToReach)
            {
                ForceExit();
            }
        }
    }
}

