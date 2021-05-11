using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBox : MonoBehaviour
{
    [SerializeField] ParticleSystem _food;

    private bool _isFoodDrop;

    private void Update()
    {
        if (_isFoodDrop)
        {
            _food.emissionRate = 100;
        }
        else
        {
            _food.emissionRate = 0;
        }
    }

    public void DropingFood(bool state)
    {
        _isFoodDrop = state;
    }
}
