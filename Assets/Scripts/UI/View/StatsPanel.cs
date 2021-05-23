using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] private Stat _food;
    [SerializeField] private Stat _energy;
    [SerializeField] private Stat _purity;
    [SerializeField] private Stat _hapiness;

    private void Awake ()
    {
        GetComponent<CanvasGroup>().DOFade(1, 0.35f);
    }

    private void SetSaves ()
    {
        Debug.Log(PlayerPrefs.GetFloat("Food"));
        Debug.Log(PlayerPrefs.GetFloat("Energy"));
        Debug.Log(PlayerPrefs.GetFloat("Clean"));
        Debug.Log(PlayerPrefs.GetFloat("Hapiness"));
    }

    public void Refresh ()
    {
        _food.Refresh();
        _energy.Refresh();
        _purity.Refresh();
        _hapiness.Refresh();
    }

    private void RemoveSaves ()
    {
        PlayerPrefs.DeleteAll();
    }
}
