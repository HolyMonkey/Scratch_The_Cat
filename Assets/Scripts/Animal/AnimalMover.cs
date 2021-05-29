using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMover : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private bool _enableJoystickMode;
    [SerializeField] private Joystick _joystick;

    private bool _isMove;
    private Vector3 _target;

    private void Update()
    {
        if (_enableJoystickMode == true)
        {
            JoystickMove();
            JoystickRotate();
        }

        if (_enableJoystickMode == false)
        {
            if (_target != default && transform.position != _target)
            {
                Move();
                Rotate();
            }

            if (transform.position == _target)
            {
                _animator.SetBool(AnimatorAnimalController.Params.IsRun, false);
            }
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _moveSpeed * Time.deltaTime);
        _animator.SetBool(AnimatorAnimalController.Params.IsRun, true);
    }

    private void Rotate()
    {
        transform.LookAt(_target);
    }

    private void JoystickMove()
    {
        Vector3 direction = Vector3.left * _joystick.Vertical + Vector3.forward * _joystick.Horizontal;
        transform.position += direction * _moveSpeed * Time.deltaTime;
    }

    private void JoystickRotate()
    {
        Vector3 direction = Vector3.left * _joystick.Vertical + Vector3.forward * _joystick.Horizontal;

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotateSpeed * Time.deltaTime);
            _animator.SetBool(AnimatorAnimalController.Params.IsRun, true);
        }
        else
        {
            _animator.SetBool(AnimatorAnimalController.Params.IsRun, false);
        }
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }

    public void EnableJoystickMode(Joystick joystick)
    {
        _enableJoystickMode = true;
        _joystick = joystick;
    }

    public void SetSpeed (float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
