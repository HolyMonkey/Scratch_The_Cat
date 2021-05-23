using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NoBowlZone : MonoBehaviour
{
    private Animal _animal;

    private float _elapsedTime = 0;

    private void Start ()
    {

    }

    public void SetAnimal (Animal animal)
    {
        _animal = animal;
    }

    private void OnParticleCollision (GameObject other)
    {
        if (_elapsedTime >= 1.5f)
        {
            _elapsedTime = 0;
            _animal.Animator.SetBool("IsAngry", true);
            Invoke("TurnOffAngry", 1.35f);
        }

    }

    private void TurnOffAngry ()
    {
        _animal.Animator.SetBool("IsAngry", false);
    }

    private void Update ()
    {
        _elapsedTime += Time.deltaTime;
    }

}
