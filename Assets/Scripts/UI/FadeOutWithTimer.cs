using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeOutWithTimer : MonoBehaviour
{
    [SerializeField] private float _secondsBeforeFadeOut;
    [SerializeField] private float _fadeTime;

    private CanvasGroup _canvasGroup;
    private float _elapsedTime = 0;

    private void Start ()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFade());
    }


    private void Update ()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBeforeFadeOut + _fadeTime)
            gameObject.SetActive(false);
    }

    private IEnumerator DoFade ()
    {
        yield return new WaitForSeconds(_secondsBeforeFadeOut);
        _canvasGroup.DOFade(0, _fadeTime);
    }
}
