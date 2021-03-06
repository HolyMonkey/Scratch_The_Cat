using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Cursor : MonoBehaviour
{
    [SerializeField] private AnimationClip _animation;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.Play(_animation.name);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
            Time.timeScale = 1;
        }
    }
}
