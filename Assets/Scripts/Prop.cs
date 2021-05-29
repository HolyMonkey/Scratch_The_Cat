using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Prop : MonoBehaviour
{
    [SerializeField] private bool _isAnimalProp = false;

    private Collider _collider;

    public event UnityAction<bool> Destroyed;

    private void Start ()
    {
        _collider = GetComponent<Collider>();
    }

    public void Touch (Vector3 direction)
    {
        transform.DOScale(0, 1f);
        transform.DORotate(new Vector3(720, 720, 720), 1f);
        GetComponent<Rigidbody>().AddForce(new Vector3(direction.x, 2f, direction.z) * 10, ForceMode.Impulse);
        _collider.enabled = false;

        if (!_isAnimalProp)
            Destroyed?.Invoke(false);
        else
            Destroyed?.Invoke(true);
    }
}
