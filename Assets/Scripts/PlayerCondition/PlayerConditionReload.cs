using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerConditionReload : MonoBehaviour
{
    public bool TryLoad(out Dictionary<PlayerConditionName, float> dictionary)
    {
        if (PlayerPrefs.HasKey(PlayerPrefName.Conditions))
        {
            string jsonCondition = PlayerPrefs.GetString(PlayerPrefName.Conditions);
            dictionary = 
            return true;
        }
    }

    public void Save(Dictionary<PlayerConditionName, float> dictionary)
    {
        string conditionsString = JsonConvert.SerializeObject(dictionary);
        PlayerPrefs.SetString(PlayerPrefName.Conditions, conditionsString);
    }
}
