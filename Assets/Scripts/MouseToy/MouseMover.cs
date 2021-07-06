using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseMover : MonoBehaviour
{
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _multiplierDuration;
    [SerializeField] private float _startSpeed;
    [SerializeField] private float[] _xCords = new float[2];
    [SerializeField] private float[] _yCords = new float[2];

    private float _moveSpeed;
    private bool _isMultiplierActive;
    private float _elapsedTime;
    private Vector3 _target;

    private void Awake()
    {
        _moveSpeed = _startSpeed;
    }

    private void Start()
    {
        SetTarget();
    }

    private void Update()
    {
        if (_isMultiplierActive)
        {
            _elapsedTime += Time.deltaTime;

            if(_elapsedTime >= _multiplierDuration)
            {
                _isMultiplierActive = false;
                _moveSpeed = _startSpeed;
                _elapsedTime = 0;
            }
        }

        if (_target == default)
            return;

        if (transform.position == _target)
        {
            SetTarget();
        }

        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _moveSpeed * Time.deltaTime);
        transform.LookAt(_target);
    }

    private void SetTarget()
    {
        Vector2 randomPosition;
        Vector3 newTarget;

        randomPosition = new Vector2(Random.Range(_xCords[0], _xCords[1]), Random.Range(_yCords[0], _yCords[1]));
        newTarget = new Vector3(randomPosition.x, transform.position.y, randomPosition.y);

        _target = newTarget;
    }

    public void Catch()
    {
        if(_isMultiplierActive == false)
        {
            _moveSpeed *= _speedMultiplier;
            _isMultiplierActive = true;
        }
    }
}
