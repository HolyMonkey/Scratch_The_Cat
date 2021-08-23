using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] private MouseMover _mouseMover;
    [SerializeField] private AudioSource _audioSource;

    public MouseMover Mover => _mouseMover;

    public void StartSqueaking()
    {
        _audioSource.Play();
    }

    public void StopSqueaking()
    {
        _audioSource.Stop();
    }
}