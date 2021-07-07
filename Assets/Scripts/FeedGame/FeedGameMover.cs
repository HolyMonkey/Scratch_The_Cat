using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedGameMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;
    [SerializeField] private float _targetPositionDelta;
    private Animator _animator;
    private Movable _movable;

    public event Action TargetReached;
    
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

    private void Start()
    {
        _animator.SetBool(AnimatorAnimalController.Params.IsRun, true);
    }

    private void Update()
    {
        Move();

        if (CheckIfTargetReached())
        {
            _animator.SetBool(AnimatorAnimalController.Params.IsRun, false);
            TargetReached?.Invoke();
            enabled = false;
        }

    }

    private void Move()
    {
        Vector3 direction = (_target.position - _movable.transform.position).normalized;
        _movable.Move(direction);
    }

    private bool CheckIfTargetReached()
    {
        float distance = Vector3.Distance(_target.position, _movable.transform.position);
        if (distance < _targetPositionDelta)
        {
            return true;
        }

        return false;
    }
}
