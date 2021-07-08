using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeButton : MonoBehaviour
{
    [SerializeField] private Animator _uiAnimator;
    [SerializeField] private Button _button;
    [SerializeField] private CustomizePanel _panel;

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
        if (_panel.IsActive == false)
        {
            _panel.Activate();
            _uiAnimator.Play("OpenCustomizePanel");
        }
    }
}
