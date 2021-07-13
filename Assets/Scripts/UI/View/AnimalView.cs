using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalView : MonoBehaviour
{
    [SerializeField] private Image _Image;
    [SerializeField] private Button _button;
    private AnimalType _animalType;

    private int _animalIndex;

    public event Action<AnimalType> AnimalChoosed; 

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Init(AnimalType animalType, Sprite sprite)
    {
        _animalType = animalType;
        _Image.sprite = sprite;
    }

    private void OnButtonClick()
    {
        AnimalChoosed?.Invoke(_animalType);
    }
}
