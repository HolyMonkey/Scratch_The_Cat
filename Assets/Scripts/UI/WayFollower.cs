using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayFollower : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _duration;

    private void Start ()
    {
        StartCoroutine(MoveToPoint());
    }

    private IEnumerator MoveToPoint ()
    {
        var secondBeforeNewIteration = new WaitForSeconds(_duration + 0.15f);

        while (true)
        {
            for (int i = 0; i < _points.Count; i++)
            {
                transform.DOMove(_points[i].position, _duration);
                
                yield return secondBeforeNewIteration;
            }
        }
    }
}
