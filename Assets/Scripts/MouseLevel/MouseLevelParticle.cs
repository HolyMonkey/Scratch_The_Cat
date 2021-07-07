using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseLevel
{
    public class MouseLevelParticle : LevelParticle
    {
        [SerializeField] private ParticleSystem _targetParticle;
        [SerializeField] private Transform _target;

        public override void PlayFail()
        {
            UIParticle.PlayFail();
        }

        public override void PlaySuccess()
        {
            _targetParticle.transform.position = _target.position;
            _targetParticle.Play();
            UIParticle.PlaySuccess();
        }

        public override void PlayWin()
        {
            UIParticle.PlayWin();
        }
    }
}

