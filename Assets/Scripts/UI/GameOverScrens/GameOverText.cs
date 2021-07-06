using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private GameOverTextVariant _winText;
    [SerializeField] private GameOverTextVariant _loseText;
    
    public void ShowLoseText()
    {
        ShowText(_loseText);
    }

    public void ShowWinText()
    {
        ShowText(_winText);
    }

    private void ShowText(GameOverTextVariant gameOverTextVariant)
    {
        _headerText.text = gameOverTextVariant.HeaderText;
        _buttonText.text = gameOverTextVariant.ButtonText;
    }
}

[Serializable]
public class GameOverTextVariant
{
    public string HeaderText;
    public string ButtonText;
}
