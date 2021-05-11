using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalView : MonoBehaviour
{
    [SerializeField] private RawImage _rawImage;
    [SerializeField] private Button _button;

    private Transform _animalPlace;
    private Animal _animalPrefab;
    private int _animalIndex;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Init(Animal animal, int index, Transform animalPlace, RenderTexture renderTexture)
    {
        _animalPlace = animalPlace;
        _animalPrefab = animal;
        _animalIndex = index;
        _rawImage.texture = renderTexture;
    }

    private void OnButtonClick()
    {
        if(_animalPlace.childCount > 0)
        {
            for (int i = 0; i < _animalPlace.childCount; i++)
            {
                Destroy(_animalPlace.GetChild(i).gameObject);
            }
        }
        Instantiate(_animalPrefab, _animalPlace);

        PlayerPrefs.SetInt("CurrentAnimal", _animalIndex);
        PlayerPrefs.Save();
    }
}
