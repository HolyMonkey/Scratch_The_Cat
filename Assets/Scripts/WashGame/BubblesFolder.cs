using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesFolder : MonoBehaviour
{
    private List<Bubbles> _bubbles;

    public void SetBubbles(List<Bubbles> bubblesList)
    {
        _bubbles = bubblesList;
    }

    public List<Bubbles> GetBubbles()
    {
        return _bubbles;
    }
}
