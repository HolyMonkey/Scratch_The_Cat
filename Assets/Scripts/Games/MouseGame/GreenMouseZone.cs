using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMouseZone : MonoBehaviour
{
    [SerializeField] private float _freezeTimeScale;
    [SerializeField] private float _secondsBeforeNewIteration;

    private bool _isInGreenZone;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<Animal>())
            _isInGreenZone = true;
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.GetComponent<Animal>())
            _isInGreenZone = false;
    }

    private void Update ()
    {
        if (_isInGreenZone)
        {
            if(Time.timeScale > _freezeTimeScale)
            {
                Time.timeScale -= Time.deltaTime;
            }
        }
        else
        {
            if(Time.timeScale != 1)
            {
                Time.timeScale += 2f * Time.deltaTime;
            }
        }
    }
}
