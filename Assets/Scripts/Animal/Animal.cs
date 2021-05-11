using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimalMover _mover;
    [SerializeField] private AnimalParticles _particles;

    public CapsuleCollider Collider => _collider;
    public AnimalMover Mover => _mover;
    public Animator Animator => _animator;
    public AnimalParticles Particles => _particles;
}
