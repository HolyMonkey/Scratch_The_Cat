using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private int _nextSceneNumber;
    
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
        _nextSceneNumber = SceneNameFolder.GetSceneNumber(type);
    }

    public void SetWinButtonEffect(SceneType type)
    {
        do
        {
            _nextSceneNumber = GetRandomSceneNumber();
        } while (_nextSceneNumber == SceneNameFolder.GetSceneNumber(type));
    }

    public void SetLoseEnergyButtonEffect()
    {
        
    }

    private void OnButtonClick()
    {
        if (_nextSceneNumber == default)
        {
            _nextSceneNumber  = GetRandomSceneNumber();
        }
        SceneManager.LoadScene(_nextSceneNumber);
    }

    private int GetRandomSceneNumber()
    {
        int number = Random.Range(0, SceneNameFolder.SceneNames.Length);
        return number;
    }
}
