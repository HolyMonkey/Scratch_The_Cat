using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WashLevel
{
    public class LatherState : WashingState
    {
        [SerializeField] private Bubbles[] _possibleBubbles;
        [SerializeField] private BubblesFolder _bubblesFolder;
        private float _deltaX = -0.1f;

        private List<Bubbles> _bubbles;

        private void Awake()
        {
            _bubbles = new List<Bubbles>();
        }

        public override void Wash()
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
            {
                Animal animal = hitInfo.collider.GetComponentInParent<Animal>();
                if (animal != null &&  hitInfo.collider.TryGetComponent(out Bubbles bubbles) == false)
                {
                    Vector3 newBabblePosition = hitInfo.point;
                    newBabblePosition.x = newBabblePosition.x + _deltaX;
                    var newBubble = Instantiate(_possibleBubbles[UnityEngine.Random.Range(0, _possibleBubbles.Length)], hitInfo.point, Quaternion.identity);
                    newBubble.transform.SetParent(animal.MovableRoot);
                    newBubble.transform.LookAt(Camera.main.transform);
                    _bubbles.Add(newBubble);
                    NotifyOnValueChange();
                }
            }

            if (_bubbles.Count >= MaxValue)
            {
                _bubblesFolder.SetBubbles(_bubbles);
                EndState();
            }
        }
    }
}

