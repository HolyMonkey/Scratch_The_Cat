using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNameFolder : MonoBehaviour
{
    private static Dictionary<SceneType, int> _nameByType = new Dictionary<SceneType, int>()
    {
        {SceneType.MouseLevel, 2},
        {SceneType.MainMenu, 1},
        {SceneType.DestroyLevel, 4},
        {SceneType.FeedLevel, 5},
        {SceneType.RunnerLevel, 7},
        {SceneType.PetLevel, 3},
        {SceneType.WashLevel, 6}
    };

    public static readonly string[] SceneNames =
    {
        "MouseGame",
        "Menu",
        "DestroyGame",
        "FeedGame",
        "PetGame",
        "RunnerGame",
        "WashGame"
    };
    
    public static int GetSceneNumber(SceneType type)
    {
        return _nameByType[type];
    }
}
