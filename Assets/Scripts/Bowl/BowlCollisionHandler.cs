using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BowlCollisionHandler : MonoBehaviour
{
    public event UnityAction FillBowl;

    private void OnParticleCollision(GameObject other)
    {
        FillBowl?.Invoke();
    }
}
