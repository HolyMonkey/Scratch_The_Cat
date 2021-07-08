using UnityEngine;

namespace MainMenu
{
    public class IdleState : AnimalState
    {
        [SerializeField] private float _stateTime;
        [SerializeField] private float _stateDeltaTime;

        private float _maxTimeForThisEnable;
        private float _currentTime;
    
        private void OnEnable()
        {
            _currentTime = 0;
            _maxTimeForThisEnable = Random.Range(_stateTime - _stateDeltaTime, _stateTime + _stateDeltaTime);
            CurrentAnimal.Animator.Play(AnimatorAnimalController.States.Idle);
        }
        

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _maxTimeForThisEnable)
            {
                ForceExit();
            }
        }
    }
}

