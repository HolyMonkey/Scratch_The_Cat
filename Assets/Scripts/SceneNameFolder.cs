using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNameFolder : MonoBehaviour
{
    private static Dictionary<SceneType, string> _nameByType = new Dictionary<SceneType, string>()
    {
        {SceneType.MouseLevel, "MouseGame"},
        {SceneType.MainMenu, "Menu"},
        {SceneType.DestroyLevel, "DestroyGame"},
        {SceneType.FeedLevel, "FeedGame"}
    };

    public static readonly string[] SceneNames =
    {
        "MouseGame",
        "Menu"
    };
        
    public static string GetSceneName(SceneType type)
    {
        return _nameByType[type];
    }
}
