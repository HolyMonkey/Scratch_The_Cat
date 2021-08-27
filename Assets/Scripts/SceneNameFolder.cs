using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneNameFolder : MonoBehaviour
{
    private static Dictionary<string, string> _levelNames = new Dictionary<string, string>()
    {
        { "DestroyGame", "destroy_game" },
        { "FeedGame", "feed_game" },
        { "MouseGame", "mouse_game" },
        { "PetGame", "pet_game" },
        { "RunnerGame", "runner_game" },
        { "WashGame", "wash_game" },
    };

    [SerializeField] private PlayerConditionFolder _conditionFolder;
    [SerializeField] private SceneGroup[] _groups;
    [SerializeField] private string _menuScene = "Menu";

    public string GetNextScene()
    {
        PlayerConditionName condition = _conditionFolder.GetLowestCondition();
        string[] possibleScenes = _groups.First(x => x.Condition == condition).Scenes;
        return possibleScenes[UnityEngine.Random.Range(0, possibleScenes.Length)];
    }

    public string GetMenuScene() => _menuScene;

    public static string GetLevelName(string sceneName) => _levelNames[sceneName];
}