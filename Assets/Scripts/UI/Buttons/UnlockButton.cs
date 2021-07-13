using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using Random = UnityEngine.Random;

public class UnlockButton : MonoBehaviour
{
    [SerializeField] private AnimalPrefabs _animalPrefabs;
    [SerializeField] private CoinsFolder _coinsFolder;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _unlockText;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private int _startUnlockValue;
    
    private int _currentUnlockValue;

    public event Action<AnimalType> AnimalUnlocked;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(PlayerPrefName.NewAnimalCost))
        {
            _currentUnlockValue = PlayerPrefs.GetInt(PlayerPrefName.NewAnimalCost);
        }
        else
        {
            _currentUnlockValue = _startUnlockValue;
        }
        ShowCurrentButton();
    }

    private void ShowCurrentButton()
    {
        if (_coinsFolder.Coins >= _currentUnlockValue && PlayerPrefs.GetInt(PlayerPrefName.UnlockAnimal) < _animalPrefabs.GetLength())
        {
            _button.interactable = true;
            _buttonImage.sprite = _sprites[0];
        }
        else
        {
            _button.interactable = false;
            _buttonImage.sprite = _sprites[1];
        }
        _unlockText.text = (_currentUnlockValue / 1000).ToString() + "K";
    }

    private void OnButtonClick()
    {
        int coins = _coinsFolder.Coins;

        if(coins >= _currentUnlockValue)
        {
            AnimalType newAnimalType = GetNewUnlockedAnimal();
            _coinsFolder.RemoveCoins(_currentUnlockValue);
            _currentUnlockValue *= 2;
            PlayerPrefs.SetInt(PlayerPrefName.NewAnimalCost, _currentUnlockValue);
            ShowCurrentButton();
            AnimalUnlocked?.Invoke(newAnimalType);
        }
    }

    private AnimalType GetNewUnlockedAnimal()
    {
        List<AnimalType> allAnimals = new List<AnimalType>();
        List<Animal> animalPrefabs = _animalPrefabs.GetAnimals();
        foreach (var animal in animalPrefabs)
        {
            allAnimals.Add(animal.Type);
        }

        List<AnimalType> unlockedAnimal = UnlockedAnimal.GetUnlockedAnimal();

        List<AnimalType> LockedAnimal = allAnimals.Except(unlockedAnimal).ToList();
        AnimalType newAnimalType = LockedAnimal[Random.Range(0, LockedAnimal.Count)];
        unlockedAnimal.Add(newAnimalType);
        UnlockedAnimal.Save(unlockedAnimal);
        return newAnimalType;
    }
}
