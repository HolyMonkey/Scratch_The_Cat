using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DestroyLevel
{
    public class JoystickMover : PlayerInput
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private float _speed;
        private Movable _movable;
        private Animator _animator;

        private void Update()
        {
            Vector3 direction = Vector3.left * _joystick.Vertical + Vector3.forward * _joystick.Horizontal;
            if (direction == Vector3.zero)
            {
                _animator.SetBool(AnimatorAnimalController.Params.IsRun, false);
            }
            else
            {
                Move(direction);
                _animator.SetBool(AnimatorAnimalController.Params.IsRun, true);
            }
        }

        public void Init(Movable movable, Animator animator)
        {
            if (_movable != null)
            {
                throw new AggregateException(this.name);
            }
            
            _movable = movable;
            _animator = animator;

            _movable.SetSpeed(_speed);
        }

        private void Move(Vector3 direction)
        {
            _movable.Move(direction);
        }
    }
}