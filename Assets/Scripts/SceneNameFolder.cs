using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNameFolder : MonoBehaviour
{
    private static Dictionary<SceneType, int> _nameByType = new Dictionary<SceneType, int>()
    {
        {SceneType.MouseLevel, 1},
        {SceneType.MainMenu, 0},
        {SceneType.DestroyLevel, 3},
        {SceneType.FeedLevel, 4},
        {SceneType.RunnerLevel, 6},
        {SceneType.PetLevel, 2},
        {SceneType.WashLevel, 5}
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
