using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    [SerializeField] private BowlCollisionHandler _collisionHandler;
    [SerializeField] private GameObject _food;
    [SerializeField] private float _minFoodY;
    [SerializeField] private float _maxFoodY;

    public BowlCollisionHandler CollisionHandler => _collisionHandler;

    public void Fill(float value)
    {
        _food.transform.localPosition = new Vector3(0, _minFoodY + (Mathf.Abs(_maxFoodY - _minFoodY) * value), 0);
    }
}
