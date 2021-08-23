using MouseLevel;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MouseSound : MonoBehaviour
{
    [SerializeField] private ScoreCalculater _scoreCalculater;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        StartSqueaking();
    }

    private void OnEnable()
    {
        _scoreCalculater.ScoreReached += StopSqueaking;
        _scoreCalculater.LosingAllScore += StopSqueaking;
    }

    private void OnDisable()
    {
        _scoreCalculater.ScoreReached -= StopSqueaking;
        _scoreCalculater.LosingAllScore -= StopSqueaking;
    }

    private void StartSqueaking() => _audioSource.Play();

    private void StopSqueaking() => _audioSource.Stop();
}