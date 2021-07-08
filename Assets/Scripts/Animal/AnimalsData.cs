using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsData : MonoBehaviour
{
    [SerializeField] private UnlockButton _unlockButton;
    [SerializeField] private CustomizePanel _customizePanel;
    [SerializeField] private Transform _animalPlace;

    [SerializeField] private AnimalPrefabs _animalPrefabs;
    [SerializeField] private RenderTexture[] _animalTextures;

    public event Action<Animal> AnimalChoyse;

    private void OnEnable()
    {
        _unlockButton.AnimalUnlocked += OnAnimalUnlocked;
    }

    private void OnDisable()
    {
        _unlockButton.AnimalUnlocked -= OnAnimalUnlocked;
    }

    private void Start()
    {
        PlayerPrefs.SetInt("TotalAnimals", _animalPrefabs.GetLength());

        for (int i = 0; i < PlayerPrefs.GetInt("UnlockedAnimals"); i++)
        {
            if (i < _animalPrefabs.GetLength())
            {
                InstantiateAnimalView(i);
            }
        }

        Animal animal = _animalPrefabs.TryGetAnimal(PlayerPrefs.GetInt("CurrentAnimal"));
        AnimalChoyse?.Invoke(animal);
    }

    private void OnAnimalUnlocked()
    {
        InstantiateAnimalView(PlayerPrefs.GetInt("UnlockedAnimals") - 1);
    }

    private void InstantiateAnimalView(int index)
    {
        //if (PlayerPrefs.GetInt("UnlockedAnimals") <= PlayerPrefs.GetInt("TotalAnimals"))
        //{
            //int index = PlayerPrefs.GetInt("UnlockedAnimals") - 1;
            var view = _customizePanel.AddAnimalView();
            view.Init(_animalPrefabs.TryGetAnimal(index), index, _animalPlace, _animalTextures[index]);
        //}
    }
}
