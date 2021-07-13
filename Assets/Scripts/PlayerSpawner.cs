using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private AnimalPrefabs _animalPrefabs;
    [SerializeField] private Transform _animalPlace;

    public Animal Spawn()
    {
        AnimalType animalType = UnlockedAnimal.GetCurrentAnimal();
        Animal animal = _animalPrefabs.GetAnimal(animalType);
        Animal newAnimal = Instantiate(animal, _animalPlace);
        return newAnimal;
    }

    public Animal Spawn(Animal animal)
    {
        var newAnimal = Instantiate(animal);
        newAnimal.transform.position = _animalPlace.position;
        return newAnimal;
    }
}

