using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Animal : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private Animator _animator;
    [SerializeField] private Movable _movable;
    [SerializeField] private AnimalParticles _particles;

    private bool _isInit;

    public CapsuleCollider Collider => _collider;
    public Movable Movable => _movable;
    public Animator Animator => _animator;
    public AnimalParticles Particles => _particles;

    public void Init(AnimalMover animalMover)
    {
        if (_isInit)
        {
            return;
        }

        gameObject.AddComponent(animalMover.GetType());

    }
}
