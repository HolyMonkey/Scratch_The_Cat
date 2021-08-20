using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Animator))]
public class LowEnergyScreen : MonoBehaviour
{
    [SerializeField] private StartButton _startButton;
    [SerializeField] private CoinsFolder _coinsFolder;
    [SerializeField] private PlayerConditionFolder _conditionFolder;
    [SerializeField] private PlayerConditionView _conditionView;
    [SerializeField] private CoinView _coinView;

    private CanvasGroup _canvasGroup;
    private Animator _animator;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
    }

    public void Enable()
    {
        _startButton.SetLoseEnergyButtonEffect();
        _conditionView.SetValue(_conditionFolder.GetValueByConditionName(PlayerConditionName.Energy));
        _coinView.SetAllCoins(_coinsFolder.Coins);

        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
        _animator.Play("Open");
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
