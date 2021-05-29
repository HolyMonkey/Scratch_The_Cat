using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalCollisionHandler : MonoBehaviour
{
    [SerializeField] private float _energyToSubstractAfterDestroy = 0.25f;

    private AnimalParticles _animalParticles;
    private bool _canDestroy = true;

    private void Awake ()
    {
        _animalParticles = GetComponent<AnimalParticles>();
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.collider.TryGetComponent(out Prop prop))
        {
            prop.Touch(collision.contacts[0].normal * -1);
            _animalParticles.FeatherExplosion.Play();

        }
    }
}
