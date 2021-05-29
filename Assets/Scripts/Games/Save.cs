using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    [SerializeField] private float _foodForLevel = 0.15f;
    [SerializeField] private float _energyForLevel = -0.15f;
    [SerializeField] private float _purityForLevel = 0.15f;
    [SerializeField] private float _hapinessForLevel = 0.15f;

    private void Awake ()
    {
        enabled = false;
    }

    private void OnEnable ()
    {
        SaveStats();
        Debug.Log("Enable");
    }

    private void SaveStats ()
    {
        PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") + _foodForLevel);
        PlayerPrefs.SetFloat("Energy", PlayerPrefs.GetFloat("Energy") + _energyForLevel);
        PlayerPrefs.SetFloat("Purity", PlayerPrefs.GetFloat("Purity") + _purityForLevel);
        PlayerPrefs.SetFloat("Hapiness", PlayerPrefs.GetFloat("Hapiness") + _hapinessForLevel);
        PlayerPrefs.Save();
    }

    public void SaveCoins (int coins)
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);
        PlayerPrefs.Save();
    }
}
