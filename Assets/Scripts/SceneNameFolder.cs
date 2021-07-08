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
        {SceneType.FeedLevel, "FeedGame"},
        {SceneType.RunnerLevel, "RunnerGame"},
        {SceneType.PetLevel, "PetGame"}
    };

    public static readonly string[] SceneNames =
    {
        "MouseGame",
        "Menu",
        "DestroyGame",
        "FeedGame",
        "PetGame",
        "RunnerGame"
    };
        
    public static string GetSceneName(SceneType type)
    {
        return _nameByType[type];
    }
}
