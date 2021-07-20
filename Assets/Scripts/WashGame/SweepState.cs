using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WashLevel
{
    public class SweepState : WashingState
    {
        [SerializeField] private BubblesFolder _bubblesFolder;
        private List<Bubbles> _bubbles;
        
        public override void Enter()
        {
            _bubbles = _bubblesFolder.GetBubbles();
        }
        
        public override void Wash()
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Bubbles bubbles) && _bubbles.Contains(bubbles))
                {
                    _bubbles.Remove(bubbles);
                    bubbles.Disappear();
                    NotifyOnValueChange();
                }
            }

            if (_bubbles.Count == 0)
            {
                EndState();
            }
        }
    }
}

