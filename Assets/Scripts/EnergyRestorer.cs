using UnityEngine;

public class EnergyRestorer : MonoBehaviour
{
    [SerializeField] private PlayerConditionViewMediator _conditionMediator;
    [SerializeField] private int _energyAmountPerTick = 1;
    [SerializeField] private float _tickLength = 1f;

    private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _tickLength)
        {
            _conditionMediator.ShowAfterAddEnergy(_energyAmountPerTick);
            _currentTime = 0;
        }
    }
}
