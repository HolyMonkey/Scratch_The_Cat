using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBoxMover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _moveSpeed;

    private int _currentWaypointIndex;
    private Transform _currentWaypoint;

    private void Start()
    {
        _currentWaypointIndex = 0;
        _currentWaypoint = _waypoints[_currentWaypointIndex];
    }

    private void Update()
    {
        Move();

        if (transform.position == _currentWaypoint.position)
            SetWaypoint();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, _moveSpeed * Time.deltaTime);
    }

    private void SetWaypoint()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex == _waypoints.Length)
            _currentWaypointIndex = 0;

        _currentWaypoint = _waypoints[_currentWaypointIndex];
    }
}
