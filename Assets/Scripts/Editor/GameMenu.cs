using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameMenu : EditorWindow
{
    [MenuItem("Game/Clear player pref")]
    public static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("Game/Add 10000 Coins")]
    public static void AddMayCoins()
    {
        int value = 10000;
        if (PlayerPrefs.HasKey(PlayerPrefName.Coin))
        {
            value += PlayerPrefs.GetInt(PlayerPrefName.Coin);
        }
        PlayerPrefs.SetInt(PlayerPrefName.Coin, value);
    }
}
