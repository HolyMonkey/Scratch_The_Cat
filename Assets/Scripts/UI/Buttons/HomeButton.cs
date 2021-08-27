using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AppMetricaStatistics _metricStats;
    [SerializeField] private StartButton _nextLevelButton;

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
        if (_nextLevelButton.IsWin)
            _metricStats.SendLevelWin(SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(0);
    }
}
