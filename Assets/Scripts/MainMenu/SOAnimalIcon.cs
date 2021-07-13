using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    [CreateAssetMenu(fileName = "MainMenuAnimalIcon", menuName = "ScriptableObjects/MainMenuAnimalIcon", order = 1)]
    public class SOAnimalIcon : ScriptableObject
    {
        [SerializeField] private AnimalType _animalType;
        [SerializeField] private Sprite _sprite;

        public AnimalType Type => _animalType;
        public Sprite AnimalIcon => _sprite;
    }
}