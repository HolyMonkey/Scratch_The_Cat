using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public static class UnlockedAnimal
{
    public static List<AnimalType> GetUnlockedAnimal()
    {
        List<AnimalType> animalTypes = new List<AnimalType>();
        if (PlayerPrefs.HasKey(PlayerPrefName.UnlockAnimal))
        {
            string unlockedListjson = PlayerPrefs.GetString(PlayerPrefName.UnlockAnimal);
            animalTypes = JsonConvert.DeserializeObject<List<AnimalType>>(unlockedListjson);
        }
        else
        {
            animalTypes.Add(AnimalType.Cat);
        }

        return animalTypes;
    }

    public static void Save(List<AnimalType> animalTypes)
    {
        string saveJson = JsonConvert.SerializeObject(animalTypes);
        PlayerPrefs.SetString(PlayerPrefName.UnlockAnimal, saveJson);
    }

    public static AnimalType GetCurrentAnimal()
    {
        AnimalType animalType = AnimalType.Cat;
        if (PlayerPrefs.HasKey(PlayerPrefName.CurrentAnimal))
        {
            string json = PlayerPrefs.GetString(PlayerPrefName.CurrentAnimal);
            animalType = JsonConvert.DeserializeObject<AnimalType>(json);
        }
        else
        {
            animalType = AnimalType.Cat;
        }

        return animalType;
    }

    public static void SaveCurrentAnimal(AnimalType animalType)
    {
        string json = JsonConvert.SerializeObject(animalType);
        PlayerPrefs.SetString(PlayerPrefName.CurrentAnimal, json);
    }
}
