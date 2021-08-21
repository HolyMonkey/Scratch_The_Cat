using UnityEngine;

public class SuccessBlock : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Animal>() != null)
            _audioSource.Play();
    }
}