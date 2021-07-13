using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private AnimalPrefabs _animalPrefabs;
    [SerializeField] private Transform _animalPlace;

    public Animal Spawn()
    {
        var animal = Instantiate(_animalPrefabs.TryGetAnimal(PlayerPrefs.GetInt("CurrentAnimal")), _animalPlace);
        return animal;
    }

    public Animal Spawn(Animal animal)
    {
        var newAnimal = Instantiate(animal);
        newAnimal.transform.position = _animalPlace.position;
        return newAnimal;
    }
}
