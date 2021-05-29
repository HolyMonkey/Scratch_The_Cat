using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _inGameParticles;
    [SerializeField] private ProgressSlider _slider;

    public event UnityAction Collided;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Animal animal))
        {
            Collided?.Invoke();

            Debug.Log("Collision");

            for (int i = 0; i < _inGameParticles.Length; i++)
            {
                if(_inGameParticles[i].isPlaying == false)
                {
                    _inGameParticles[i].Play();
                    i = _inGameParticles.Length;
                }

                _slider.ChangeValue(-0.1f);
                Camera.main.DOShakeRotation(0.2f, 5, 1, 0);
            }
        }
    }
}
