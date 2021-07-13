using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Sprite _energyButtonSprite;
    
    private Action ButtohHandler;

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
        ButtohHandler += ChangeLevel;
    }

    public void SetWinButtonEffect(SceneType type)
    {
        do
        {
            _nextSceneNumber = GetRandomSceneNumber();
        } while (_nextSceneNumber == SceneNameFolder.GetSceneNumber(type));
        Debug.Log("Scene in folder = " + SceneNameFolder.GetSceneNumber(type));
        Debug.Log("RandomNumber = " + _nextSceneNumber);

        ButtohHandler += ChangeLevel;

    }

    public void SetLoseEnergyButtonEffect()
    {
        _button.image.sprite = _energyButtonSprite;
        ColorBlock colorBlock = _button.colors;
        Color color = colorBlock.disabledColor;
        color.a = 1;
        colorBlock.disabledColor = color;
        _button.colors = colorBlock;
        
        _nextSceneNumber = GetRandomSceneNumber();
    }

    private void ChangeLevel()
    {
        if (_nextSceneNumber == default)
        {
            _nextSceneNumber  = GetRandomSceneNumber();
        }
        SceneManager.LoadScene(_nextSceneNumber);
    }

    private void ChangeLevelWithAddEnergy()
    {
        if (_nextSceneNumber == default)
        {
            _nextSceneNumber  = GetRandomSceneNumber();
        }
        SceneManager.LoadScene(_nextSceneNumber);
    }

    private void OnButtonClick()
    {
        ButtohHandler?.Invoke();
    }

    private int GetRandomSceneNumber()
    {
        int number = Random.Range(0, SceneNameFolder.SceneNames.Length);
        return number;
    }
}
