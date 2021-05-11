using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        int randomScene;
        do
        {
            randomScene = GetRandomSceneIndex();
        } while (PlayerPrefs.GetInt("LastScene") == randomScene);
        
        PlayerPrefs.SetInt("LastScene", randomScene);
        PlayerPrefs.Save();
        SceneManager.LoadScene(randomScene);
    }

    private int GetRandomSceneIndex()
    {
        return Random.Range(1, SceneManager.sceneCountInBuildSettings);
    }
}
