using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsInIdle : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _animalPlace;

    private Animal _animal;
    private AnimalMover _animalMover;
    private int _currentPoint = 0;
    private bool _isMoving = true;
    private bool _updateWork = true;

    private void Start ()
    {
    }

    private void Update ()
    {
        if(_animal == null)
        {
            _animal = _animalPlace.GetComponentInChildren<Animal>();
            _animalMover = _animal.GetComponentInChildren<AnimalMover>();
        }

        if (_updateWork)
        {
            if (_currentPoint == _points.Length)
            {
                _currentPoint = 0;
            }

            if (_isMoving)
            {
                _animalMover.transform.position = Vector3.Lerp(_animalMover.transform.position, _points[_currentPoint].position, 3 * Time.deltaTime);
                //_animal.Animator.SetBool("IsWalked", true);
            }

            if (_animal.transform.position == _points[_currentPoint].position)
            {
                _isMoving = false;
                _updateWork = false;
                _animal.Animator.SetBool("IsWalked", false);
                StartCoroutine(DoSomeActions());
            }
        }
    }

    private IEnumerator DoSomeActions ()
    {
        var waitingSeconds = new WaitForSeconds(Random.Range(1.5f, 5));
        yield return waitingSeconds;

        if (PlayerPrefs.GetFloat("Hapiness") >= 0.6f)
        {
            _animal.Animator.SetBool("IsHappy", true);
            yield return waitingSeconds;
            _animal.Animator.SetBool("IsHappy", false);
        }
        else
        {
            _animal.Animator.SetBool("IsAngry", true);
            yield return waitingSeconds;
            _animal.Animator.SetBool("IsAngry", false);
        }

        yield return waitingSeconds;

        _currentPoint++;
        _updateWork = true;
    }
}
