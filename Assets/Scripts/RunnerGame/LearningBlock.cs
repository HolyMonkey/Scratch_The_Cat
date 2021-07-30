using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class LearningBlock : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private float _time;
    [SerializeField] private Cursor _cursor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Animal animal))
            StartCoroutine(ShowText(_time));
    }

    private IEnumerator ShowText(float time)
    {
        _cursor.gameObject.SetActive(true);
        _text.SetActive(true);
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(time);
        _text.SetActive(false);
        Time.timeScale = 1f;
        _cursor.gameObject.SetActive(false);
    }
}