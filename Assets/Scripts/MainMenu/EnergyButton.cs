using System;
using UnityEngine;
using UnityEngine.UI;

public class EnergyButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        
    }
}
