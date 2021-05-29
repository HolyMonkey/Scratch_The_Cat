using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBoxMover : MonoBehaviour
{
    [SerializeField] private Transform[] _horizontalPoints;
    [SerializeField] private Transform[] _verticalPoints;
    [SerializeField] private Transform _centerPoint;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _addingSpeedForce = 1;
    [SerializeField] private float _countDown;

    private int _currentWaypointIndex;
    private Transform _currentWaypoint;
    private Transform[] _currentWaypoints;
    private bool _isPickingUpSpeed = true;

    private void Start ()
    {
        StartCoroutine(CountDownActions());
        WriteNewPoints(_horizontalPoints);
        _currentWaypointIndex = 0;
        _currentWaypoint = _currentWaypoints[_currentWaypointIndex];
    }

    private void Update ()
    {
        Move();

        if (_isPickingUpSpeed)
        {
            _moveSpeed += _addingSpeedForce * Time.deltaTime;

            if (_moveSpeed >= _maxSpeed)
                _isPickingUpSpeed = false;
        }
        else if (!_isPickingUpSpeed)
        {
            _moveSpeed -= _addingSpeedForce * Time.deltaTime;

            if (_moveSpeed <= _minSpeed)
                _isPickingUpSpeed = true;
        }

        if (transform.position == _currentWaypoint.position)
            SetWaypoint();
    }

    private IEnumerator CountDownActions ()
    {
        var secondsBeforeRefresh = new WaitForSeconds(_countDown);
        float timeLeft = 0;

        while (true)
        {
            timeLeft += _countDown;

            if (timeLeft >= 5)
            {
                _currentWaypoint = _centerPoint;
                yield return new WaitForSeconds(0.5f);

                if (_currentWaypoints == _horizontalPoints)
                    _currentWaypoints = _verticalPoints;
                else
                    _currentWaypoints = _horizontalPoints;
            }

            yield return secondsBeforeRefresh;
        }
    }

    private void WriteNewPoints (Transform[] points)
    {
        _currentWaypoints = points;
    }

    private void Move ()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, _moveSpeed * Time.deltaTime);
    }

    private void SetWaypoint ()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex == _currentWaypoints.Length)
            _currentWaypointIndex = 0;

        _currentWaypoint = _currentWaypoints[_currentWaypointIndex];
    }
}
