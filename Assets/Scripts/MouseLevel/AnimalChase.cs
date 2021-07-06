using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class AnimalChase : AnimalMover
    {
        [SerializeField] private float _normalSpeed;
        [SerializeField, Range(0f, 1f)] private float _speedMultipler;
        [SerializeField] private PlayerPositionLooker _playerPositionLooker;
        private Movable _movable;
        private Animator _animator;
        private Transform _target;
        private PlayerPositionType _typeForNormalSpeed = PlayerPositionType.Outside;

        private void OnEnable()
        {
            _playerPositionLooker.PositionChanged += ChangeSpeedIfNeeded;
        }

        private void OnDisable()
        {
            _playerPositionLooker.PositionChanged -= ChangeSpeedIfNeeded;
        }

        private void Start()
        {
            _animator.SetBool(AnimatorAnimalController.Params.IsRun, true);
        }

        private void Update()
        {
            Move();
        }

        private void ChangeSpeedIfNeeded(PlayerPositionType type)
        {
            if (type == _typeForNormalSpeed)
            {
                RemoveSpeed();
            }
            else
            {
                ReduseSpeed();
            }
        }

        private void ReduseSpeed()
        {
            float speed = _normalSpeed * _speedMultipler;
            _movable.SetSpeed(speed);
        }

        private void RemoveSpeed()
        {
            _movable.SetSpeed(_normalSpeed);
        }
        
        private void Move()
        {
            Vector3 direction = (_target.position - _movable.transform.position).normalized;
            _movable.Move(direction);
        }

        public void Init(Movable movable, Animator animator)
        {
            if (_movable != null)
            {
                throw new AggregateException(this.name);
            }

            _movable = movable;
            _movable.SetSpeed(_normalSpeed);
            _animator = animator;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
} 
