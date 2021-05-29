using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BowlCollisionHandler : MonoBehaviour
{
    [SerializeField] private float _rotationDuration;
    [SerializeField] private float _rotationStrength;
    [SerializeField] private bool _isBowl = true;

    public event UnityAction<bool> FillBowl;

    private void OnParticleCollision(GameObject other)
    {
        FillBowl?.Invoke(_isBowl);

        transform.DOComplete();
        transform.DOShakeRotation(_rotationDuration, _rotationStrength);
    }
}
