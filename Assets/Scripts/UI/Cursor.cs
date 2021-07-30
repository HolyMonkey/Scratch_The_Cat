using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Cursor : MonoBehaviour
{
    public event Action Clicked;

    [SerializeField] private AnimationClip _animation;

    private Animator _animator;
    private bool _vanished;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.Play(_animation.name);

        if (_vanished == false)
            Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && _vanished == false)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            Clicked?.Invoke();
            _vanished = true;
        }
    }
}
