using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
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
        _uiAnimator.Play("CloseCustomizePanel");
        _panel.SetActive(false);
    }
}
