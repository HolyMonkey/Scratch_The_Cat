using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UnlockButton : MonoBehaviour
{
    [SerializeField] private CoinView _coinsView;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _unlockText;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private int _startUnlockValue;

    public event UnityAction AnimalUnlocked;

    private int _currentUnlockValue;

    private void Start()
    {
        _currentUnlockValue = PlayerPrefs.GetInt("UnlockValue");
        _unlockText.text = (_currentUnlockValue / 1000).ToString() + "K";
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Coins") >= _currentUnlockValue && PlayerPrefs.GetInt("UnlockedAnimals") < PlayerPrefs.GetInt("TotalAnimals"))
        {
            _button.interactable = true;
            _buttonImage.sprite = _sprites[0];
        }
        else
        {
            _button.interactable = false;
            _buttonImage.sprite = _sprites[1];
        }
    }

    private void OnButtonClick()
    {
        int coins = PlayerPrefs.GetInt("Coins");

        if(coins >= _currentUnlockValue)
        {
            //_coinsView.ChangeCoinsCount(_currentUnlockValue);
            PlayerPrefs.SetInt("UnlockedAnimals", PlayerPrefs.GetInt("UnlockedAnimals") + 1);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - _currentUnlockValue);

            PlayerPrefs.SetInt("UnlockValue", PlayerPrefs.GetInt("UnlockValue") * 2);
            _currentUnlockValue = PlayerPrefs.GetInt("UnlockValue");
            _unlockText.text = (_currentUnlockValue / 1000).ToString() + "K";
            PlayerPrefs.Save();
            AnimalUnlocked?.Invoke();
        }
    }
}
