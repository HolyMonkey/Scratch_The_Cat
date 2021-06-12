using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LostzoneCollisionHandler : MonoBehaviour
{
    public event UnityAction LostFeed;

    private void OnParticleCollision(GameObject other)
    {
        LostFeed?.Invoke();
    }
}
