using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimalPrefabs : MonoBehaviour
{
    [SerializeField] private Animal[] _animals;

    public bool TryGetAnimal(int index, out Animal animal)
    {
        if (index >= _animals.Length)
        {
            animal = null;
            return false;
        }

        animal = _animals[index];
        return true;
    }

    public Animal GetBaseAnimal()
    {
        Animal animal = GetAnimal(AnimalType.Cat);
        return animal;
    }

    public Animal GetAnimal(AnimalType animalType)
    {
        Animal animal = _animals.First(a => a.Type == animalType);
        return animal;
    }

    public List<Animal> GetAnimals()
    {
        return _animals.ToList();
    }

    public int GetLength()
    {
        return _animals.Length;
    }
}
