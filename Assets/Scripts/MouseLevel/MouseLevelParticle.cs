using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class MouseLevelParticle : MonoBehaviour
    {
        [SerializeField] private Particle _particle;
        [SerializeField] private ParticleSystem _targetParticle;
        [SerializeField] private Transform _target;

        public void PlayFail()
        {
            _particle.PlayFail();
        }

        public void PlaySuccess()
        {
            _targetParticle.transform.position = _target.position;
            _targetParticle.Play();
            _particle.PlaySuccess();
        }

        public void PlayWin()
        {
            _particle.PlayWin();
        }
    }
}

