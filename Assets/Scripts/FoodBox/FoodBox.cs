using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBox : MonoBehaviour
{
    [SerializeField] ParticleSystem _food;
    [SerializeField] private AudioSource _audioSource;

    private bool _isFoodDrop;

    private void Update()
    {
        if (_isFoodDrop)
        {
            _food.emissionRate = 200;
        }
        else
        {
            _food.emissionRate = 0;
        }
    }

    public void DropingFood(bool state)
    {
        _isFoodDrop = state;

        if (_isFoodDrop)
            _audioSource.Play();
        else
            _audioSource.Stop();
    }
}
