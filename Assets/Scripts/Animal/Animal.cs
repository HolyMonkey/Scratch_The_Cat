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
    [SerializeField] private AnimalType _animalType;
    [SerializeField] private Transform _movableRoot;

    public AnimalType Type => _animalType;
    
    public CapsuleCollider Collider => _collider;
    public Movable Movable => _movable;
    public Animator Animator => _animator;
    public AnimalParticles Particles => _particles;
    public Transform MovableRoot => _movableRoot;
}
