using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollisionHandler : MonoBehaviour
{
    private AnimalParticles _animalParticles;

    private void Awake()
    {
        _animalParticles = GetComponent<AnimalParticles>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Prop prop))
        {
            _animalParticles.FeatherExplosion.Play();
        } 
    }
}
