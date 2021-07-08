using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class MainMenuPosiblePositionToMove : MonoBehaviour
    {
        [SerializeField] private Transform[] _positions;

        public Transform GetRandomPosition()
        {
            return _positions[Random.Range(0, _positions.Length)];
        }
    }
}
