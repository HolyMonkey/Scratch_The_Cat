using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private string _nextSceneName;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void SetLoseButtonEffect(SceneType type)
    {
        _nextSceneName = SceneNameFolder.GetSceneName(type);
    }

    public void SetWinButtonEffect(SceneType type)
    {
        do
        {
            _nextSceneName = GetRandomSceneName();
        } while (_nextSceneName == SceneNameFolder.GetSceneName(type));
    }

    public void SetLoseEnergyButtonEffect()
    {
        
    }

    private void OnButtonClick()
    {
        if (_nextSceneName == default)
        {
            _nextSceneName  = GetRandomSceneName();
        }
        SceneManager.LoadScene(_nextSceneName);
    }

    private string GetRandomSceneName()
    {
        return SceneNameFolder.SceneNames[Random.Range(0, SceneNameFolder.SceneNames.Length)];
    }
}
