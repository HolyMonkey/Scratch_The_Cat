using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DestroyLevel
{
    public class DestroyLecelParticle : LevelParticle
    {
        public override void PlayFail()
        {
            UIParticle.PlayFail();
        }

        public override void PlaySuccess()
        {
            UIParticle.PlaySuccess();
        }

        public override void PlayWin()
        {
            UIParticle.PlayWin();
        }
    }
}


