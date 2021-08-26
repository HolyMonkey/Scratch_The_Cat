using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneNameFolder : MonoBehaviour
{
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
}