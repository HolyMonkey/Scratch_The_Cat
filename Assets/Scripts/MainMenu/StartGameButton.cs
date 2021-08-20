using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class StartGameButton : MonoBehaviour
    {
        [SerializeField] private SceneType _sceneType;
        [SerializeField] private Button _button;
        [SerializeField] private PlayerConditionFolder _conditionFolder;
        [SerializeField] private SceneGroup[] _groups;
        [SerializeField] private LowEnergyScreen _lowEnergyScreen;

        private void OnEnable()
        {
            _button.onClick.AddListener(LoadScene);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(LoadScene);
        }

        private void LoadScene()
        {
            if (_conditionFolder.GetValueByConditionName(PlayerConditionName.Energy) >= _conditionFolder.LevelEnergyCost)
                SceneManager.LoadScene(GetNeccessaryScene());
            else
                _lowEnergyScreen.Enable();
        }

        private string GetNeccessaryScene()
        {
            PlayerConditionName condition = _conditionFolder.GetLowestCondition();
            string[] possibleScenes = _groups.First(x => x.Condition == condition).Scenes;
            return possibleScenes[UnityEngine.Random.Range(0, possibleScenes.Length)];
        }
    }
}