using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndText : MonoBehaviour
{
    [SerializeField] private GameObject _levelComplete;
    [SerializeField] private GameObject _failScreen;

    public void ShowEndScreen(bool isLevelComplete)
    {
        if (isLevelComplete)
        {
            _failScreen.SetActive(false);
        }
        else
        {
            _levelComplete.SetActive(false);
        }
    }
}


