using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBox : MonoBehaviour
{
    [SerializeField] ParticleSystem _food;
    [SerializeField] private float _maxRotationX;
    [SerializeField] private float _minRotationX;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _emmissionRateOnFoodDrop;

    private bool _isFoodDrop;
    private Vector3 _normalRotation;

    private void Awake ()
    {
        _normalRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        transform.DORotate(new Vector3(_normalRotation.x, 180, transform.localRotation.z), 0.15f);
    }

    private void Update()
    {
        if (_isFoodDrop)
        {
            _food.emissionRate = _emmissionRateOnFoodDrop;
        }
        else
        {
            _food.emissionRate = 0;
        }
    }

    public void DropingFood (bool state)
    {
        _isFoodDrop = state;

        transform.DOComplete();

        if (state)
            transform.DORotate(new Vector3(transform.localRotation.x + _maxRotationX, 180, transform.localRotation.z), 0.15f);
        else
            transform.DORotate(new Vector3(_normalRotation.x, 180, transform.localRotation.z), 0.15f);
    }
}
