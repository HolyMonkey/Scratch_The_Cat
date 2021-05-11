using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _currentAnimal;

    public int Coins { get; private set; }

    private void Awake()
    {
        //PlayerPrefs.DeleteKey("UnlockedAnimals");
        //PlayerPrefs.DeleteKey("CurrentAnimal");
        //PlayerPrefs.DeleteKey("UnlockValue");
        //PlayerPrefs.SetInt("Coins", 0);

        if (!PlayerPrefs.HasKey("LastScene"))
            PlayerPrefs.SetInt("LastScene", 0);

        if (!PlayerPrefs.HasKey("Coins"))
            PlayerPrefs.SetInt("Coins", 0);

        if (!PlayerPrefs.HasKey("TotalAnimals"))
           PlayerPrefs.SetInt("TotalAnimals", 0);

        if (!PlayerPrefs.HasKey("UnlockedAnimals"))
            PlayerPrefs.SetInt("UnlockedAnimals", 1);

        if (!PlayerPrefs.HasKey("CurrentAnimal"))
            PlayerPrefs.SetInt("CurrentAnimal", 0);

        if (!PlayerPrefs.HasKey("UnlockValue"))
            PlayerPrefs.SetInt("UnlockValue", 1000);

        Coins = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.Save();
    }
}
