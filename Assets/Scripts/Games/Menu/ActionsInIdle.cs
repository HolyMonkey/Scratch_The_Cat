using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsInIdle : MonoBehaviour
{
    [SerializeField] private Transform _pointsParent;
    [SerializeField] private Transform _animalPlace;
    [SerializeField] private float _secondsGoToPoint;
    [SerializeField] private float _minDoActionSeconds;
    [SerializeField] private float _maxDoActionSeconds;

    private Transform _animalTransform;
    private Transform[] _points;
    private Animal _animal;
    private int _currentPoint = 0;
    private bool _timer = true;
    private float _elapsedTime;

    private void Start ()
    {
        _points = new Transform[_pointsParent.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _pointsParent.GetChild(i);
    }

    private void Update ()
    {
        if (_timer)
            _elapsedTime += Time.deltaTime;

        if (_animalTransform == null)
        {
            _animalTransform = _animalPlace.GetChild(0);
            _animal = _animalTransform.GetComponent<Animal>();
            Destroy(_animal.GetComponent<AnimalMover>());
            MoveAnimalToPosition();
        }

        if (_animal != null)
        {
            if (_elapsedTime >= _secondsGoToPoint + 1)
            {
                _elapsedTime = 0;
                _timer = false;
                StartCoroutine(DoRandomAction());
            }

            if (_elapsedTime >= _secondsGoToPoint - 1)
            {
                _animal.Animator.SetBool("IsWalked", false);
            }
        }
    }

    private void MoveAnimalToPosition ()
    {
        if (_currentPoint == _points.Length)
            _currentPoint = 0;

        _timer = true;
        _animal.Animator.SetBool("IsWalked", true);
        _animalTransform.DOMove(_points[_currentPoint].position, _secondsGoToPoint);
        _animalTransform.DOLookAt(_points[_currentPoint].position, 0.15f);
        _currentPoint++;
    }

    private IEnumerator DoRandomAction ()
    {
        var secondsBeforeMove = new WaitForSeconds(Random.Range(_minDoActionSeconds, _maxDoActionSeconds));
        int randomValue = Random.Range(1, 3);
        _timer = false;

        if(randomValue == 1)
        {
            if (PlayerPrefs.GetFloat("Hapiness") < 0.25f)
            {
                _animal.Animator.SetBool("IsAngry", true);
                yield return secondsBeforeMove;
                _animal.Animator.SetBool("IsAngry", false);
            }
            else
            {
                _animal.Animator.SetTrigger("Happy");
                yield return secondsBeforeMove;
            }
        }

        MoveAnimalToPosition();
        _timer = true;
    }
}
