using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerGameMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _targetDistanceToComplite;
    private Movable _movable;
    private Vector3 _target;

    public event Action PositionReached; 
    
    private void Update()
    {
        Move();

        if (CheckIfReachedTarget())
        {
            PositionReached?.Invoke();
            enabled = false;
        }
    }

    public void Init(Movable movable, Vector3 target)
    {
        if (_movable != null)
        {
            throw new AggregateException(this.name);
        }

        _target = target;
        _movable = movable;
        _movable.SetSpeed(_speed);
    }

    private void Move()
    {
        Vector3 direction = (_target - _movable.transform.position).normalized;
        _movable.Move(direction);
    }

    private bool CheckIfReachedTarget()
    {
        float distance = Vector3.Distance(_movable.transform.position, _target);
        if (distance < _targetDistanceToComplite)
        {
            return true;
        }

        return false;
    }
}
