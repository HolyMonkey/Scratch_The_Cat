using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bubbles : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private WashGame _washGame;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_washGame.Phase == 2)
            Destroy(gameObject);
    }

    public void Init(WashGame washGame)
    {
        _washGame = washGame;
    }
}
