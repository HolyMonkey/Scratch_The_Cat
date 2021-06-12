using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lostzone : MonoBehaviour
{
    [SerializeField] private LostzoneCollisionHandler _collisionHandler;

    public LostzoneCollisionHandler CollisionHandler => _collisionHandler;

}
