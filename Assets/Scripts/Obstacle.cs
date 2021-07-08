using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _inGameParticles;
    [SerializeField] private ProgressSlider _slider;
    [SerializeField] private Particle _particle;

    public event UnityAction Collided;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Animal animal))
        {
            Collided?.Invoke();
            
            _particle.PlayFail();
            
            Camera.main.DOShakeRotation(0.2f, 5, 1, 0);
        }
    }
}
