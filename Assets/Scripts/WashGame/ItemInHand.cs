using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInHand : MonoBehaviour
{
    private WashingItemType _washingItemType;

    public void SetItemInHand(WashingItemType washingItemType)
    {
        _washingItemType = washingItemType;
    }

    public WashingItemType GetItemInHand()
    {
        return _washingItemType;
    }
}
