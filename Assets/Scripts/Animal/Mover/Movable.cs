using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Movable : MonoBehaviour
{
    protected float _speed;

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void Move(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
        Rotate(direction);
    }

    private void Rotate(Vector3 direction)
    {
        transform.LookAt(transform.position + direction);
    }
}
