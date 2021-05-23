using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BowlCollisionHandler : MonoBehaviour
{
    [SerializeField] private float _rotationDuration;
    [SerializeField] private float _rotationStrength;

    public event UnityAction FillBowl;

    private void OnParticleCollision(GameObject other)
    {
        FillBowl?.Invoke();

        transform.DOComplete();
        transform.DOShakeRotation(_rotationDuration, _rotationStrength);
    }
}
