using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MainMenu;
using Newtonsoft.Json;
using UnityEngine;

public class AnimalsData : MonoBehaviour
{
    [SerializeField] private SOAnimalIcon[] _animalIcons;
    [SerializeField] private UnlockButton _unlockButton;
    [SerializeField] private CustomizePanel _customizePanel;
    [SerializeField] private AnimalPrefabs _animalPrefabs;
    private Animal _animal;
    private List<AnimalView> _animalViews;
    private List<AnimalType> _unlockedAnimalTypes;
    public event Action<Animal> AnimalChoosed;

    private void OnEnable()
    {
        _unlockButton.AnimalUnlocked += OnAnimalUnlocked;
    }

    private void OnDisable()
    {
        _unlockButton.AnimalUnlocked -= OnAnimalUnlocked;
        foreach (var view in _animalViews)
        {
            view.AnimalChoosed -= OnAnimalChoose;
        }
    }

    private void Start()
    {
        _animalViews = new List<AnimalView>();
        _unlockedAnimalTypes = UnlockedAnimal.GetUnlockedAnimal();

        for (int i = 0; i < _unlockedAnimalTypes.Count; i++)
        {
            if (i < _animalPrefabs.GetLength())
            {
                InstantiateAnimalView(_unlockedAnimalTypes[i]);
            }
        }

        AnimalType animalType = UnlockedAnimal.GetCurrentAnimal();
        Animal animal = _animalPrefabs.GetAnimal(animalType);
        AnimalChoosed?.Invoke(animal);
    }

    private void OnAnimalUnlocked(AnimalType animalType)
    {
        InstantiateAnimalView(animalType);
    }

    private void InstantiateAnimalView(AnimalType animalType)
    {
        var view = _customizePanel.AddAnimalView();
        _animalViews.Add(view);
        view.AnimalChoosed += OnAnimalChoose;
        Sprite animalIcon = _animalIcons.First(icon => icon.Type == animalType).AnimalIcon;

        view.Init(animalType, animalIcon);
    }

    private void OnAnimalChoose(AnimalType animalType)
    {
        Animal animal = _animalPrefabs.GetAnimal(animalType);
        UnlockedAnimal.SaveCurrentAnimal(animalType);
        AnimalChoosed?.Invoke(animal);
    }
}
