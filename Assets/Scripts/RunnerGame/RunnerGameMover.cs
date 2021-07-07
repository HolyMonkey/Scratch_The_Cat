using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerGameMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Movable _movable;
    private Vector3 _target;

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

    private void Update()
    {
        Vector3 direction = (_target - _movable.transform.position).normalized;
        _movable.Move(direction);
    }
}
