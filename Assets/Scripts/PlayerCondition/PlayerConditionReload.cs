using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public static class PlayerConditionReload
{
    public static bool TryLoad(out Dictionary<PlayerConditionName, float> dictionary)
    {
        if (PlayerPrefs.HasKey(PlayerPrefName.Conditions))
        {
            string jsonCondition = PlayerPrefs.GetString(PlayerPrefName.Conditions);
            var deserializeObjectdictionary = JsonConvert.DeserializeObject<Dictionary<PlayerConditionName, float>>(jsonCondition);
            dictionary = deserializeObjectdictionary;
            Debug.Log("HAve");
            return true;
        }

        dictionary = null;
        return false;
    }

    public static void Save(Dictionary<PlayerConditionName, float> dictionary)
    {
        string conditionsString  = JsonConvert.SerializeObject(dictionary);
        PlayerPrefs.SetString(PlayerPrefName.Conditions, conditionsString);
        TimeOutOfGameCalculator.SaveLastConditionUpdateTime();
    }
}
