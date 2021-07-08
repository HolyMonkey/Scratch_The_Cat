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
}
