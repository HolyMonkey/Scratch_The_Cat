using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class StartGameButton : MonoBehaviour
    {
        [SerializeField] private SceneType _sceneType;
        [SerializeField] private Button _button;
        
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
            int number = 0;
            do
            {
                number = GetRandomSceneNumber();
            } while (number == SceneNameFolder.GetSceneNumber(_sceneType));

            SceneManager.LoadScene(number);
        }

        private int GetRandomSceneNumber()
        {
            int number = Random.Range(0, SceneNameFolder.SceneNames.Length);
            return number;
        }
    }
}