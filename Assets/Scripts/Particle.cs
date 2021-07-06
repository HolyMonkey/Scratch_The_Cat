using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _failParticle;
    [SerializeField] private ParticleSystem[] _winParticle;
    [SerializeField] private ParticleSystem[] _successParticles;

    public void PlaySuccess()
    {
        PlayOneOfNotPlaing(_successParticles);
    }

    public void PlayFail()
    {
        PlayOneOfNotPlaing(_failParticle);
    }

    public void PlayWin()
    {
        PlayAll(_winParticle);
    }

    private void PlayOneOfNotPlaing(ParticleSystem[] particles)
    {
        foreach (var particle in particles)
        {
            if (particle.isPlaying == false)
            {
                particle.Play();
                return;
            }
        }
    }

    private void PlayAll(ParticleSystem[] particles)
    {
        foreach (var particle in particles)
        {
            particle.Play();
        }
    }
}
