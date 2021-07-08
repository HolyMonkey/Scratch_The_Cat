using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private bool _smoothMove;
    [SerializeField] private bool _followTarget;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetZ;

    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxZ;
    [SerializeField] private float _minZ;

    private Animal _animal;

    private void Update()
    {
        if (_followTarget)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 targetPosition;

        if (_smoothMove)
        {
            targetPosition = new Vector3(_animal.transform.position.x + _offsetX, transform.position.y, _animal.transform.position.z + _offsetZ);
            transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(targetPosition.x, _minX, _maxX), targetPosition.y, Mathf.Clamp(targetPosition.z, _minZ, _maxZ)), _moveSpeed * Time.deltaTime);
        }
        else
        {
            targetPosition = new Vector3(_animal.transform.position.x + _offsetX, transform.position.y, transform.position.z);
            transform.position = targetPosition;
        }
    }

    public void SetTarget(Animal animal)
    {
        _animal = animal;
    }
}
