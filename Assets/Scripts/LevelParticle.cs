using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelParticle : MonoBehaviour
{
    [SerializeField] private Particle _UIparticle;

    protected Particle UIParticle => _UIparticle;
    public abstract void PlayFail();

    public abstract void PlaySuccess();

    public abstract void PlayWin();
}
