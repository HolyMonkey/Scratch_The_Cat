using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class Bubbles : MonoBehaviour
{
    private Animator _animator;
    private UnityAction _objectDestroyed;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Disappear()
    {
        _animator.SetTrigger("Destroy");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}