using System;
using UnityEngine;

[Serializable]
public class SceneGroup
{
    [SerializeField] private string[] _scenes;
    [SerializeField] private PlayerConditionName _condition;

    public string[] Scenes => _scenes;
    public PlayerConditionName Condition => _condition;
}