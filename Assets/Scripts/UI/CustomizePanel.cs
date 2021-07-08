using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CustomizePanel : MonoBehaviour
{
    [SerializeField] private AnimalView _viewPrefab;
    [SerializeField] private Transform _viewContainer;

    public bool IsActive => _isActive;

    private bool _isActive;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Activate()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        _isActive = true;
    }

    public void Deactivate()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _isActive = false;
    }

    public AnimalView AddAnimalView()
    {
        return Instantiate(_viewPrefab, _viewContainer);
    }
}
