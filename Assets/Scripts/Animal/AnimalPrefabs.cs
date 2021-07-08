using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPrefabs : MonoBehaviour
{
    [SerializeField] private Animal[] _animals;

    public Animal TryGetAnimal(int index)
    {
        Animal animal = null;

        if (index < _animals.Length)
            animal = _animals[index];

        return animal;
    }

    public int GetLength()
    {
        return _animals.Length;
    }
}
