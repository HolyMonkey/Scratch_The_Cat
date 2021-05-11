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
            prop.Touch(collision.contacts[0].normal * -1);
            //var explosion = Instantiate(_animalParticles.FeatherExplosion, collision.contacts[0].point, Quaternion.identity);
            _animalParticles.FeatherExplosion.Play();
        } 
    }
}
