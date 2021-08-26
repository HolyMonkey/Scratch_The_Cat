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
        [SerializeField] private LowEnergyScreen _lowEnergyScreen;
        [SerializeField] private SceneNameFolder _sceneNameFolder;

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
                SceneManager.LoadScene(_sceneNameFolder.GetNextScene());
            else
                _lowEnergyScreen.Enable();
        }
    }
}