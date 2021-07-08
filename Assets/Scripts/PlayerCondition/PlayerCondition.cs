using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCondition : MonoBehaviour
{
    [SerializeField] private PlayerConditionReload _playerConditionReload;
    private Dictionary<PlayerConditionName, float> _conditions;
}
