using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using DG.Tweening;
using Random = UnityEngine.Random;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private StatsPanel _statsPanel;
    [SerializeField] private List<int> _foodScenesIndex;
    [SerializeField] private List<int> _purityScenesIndex;
    [SerializeField] private List<int> _hapinessScenesIndex;
    [SerializeField] private CanvasGroup _watchVideoForEnergy;
    [SerializeField] private float _energyValueWhenWatchVideoForEnergyActivated = 0.15f;

    List<string> _stats = new List<string> { "Food", "Purity", "Hapiness" };

    private void Start ()
    {
        if (PlayerPrefs.HasKey("Energy") && PlayerPrefs.GetFloat("Energy") < _energyValueWhenWatchVideoForEnergyActivated)
            ActivateWatchVideoForEnergy();
    }

    private void OnEnable ()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable ()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private int ChooseLevel ()
    {
        List<float> statsValues = new List<float> { PlayerPrefs.GetFloat(_stats[0]), PlayerPrefs.GetFloat(_stats[1]), PlayerPrefs.GetFloat(_stats[2]) };
        float lowestStat = statsValues.Min();
        int statIndex = 0;
        int sceneIndex = 0;

        for (int i = 0; i < statsValues.Count; i++)
        {
            if (lowestStat == statsValues[i])
                statIndex = i;
        }

        switch (statIndex)
        {
            case 0:
                Debug.Log("Need Food");
                sceneIndex = _foodScenesIndex[Random.Range(0, _foodScenesIndex.Count)];
                break;
            case 1:
                Debug.Log("Need purity");
                sceneIndex = _purityScenesIndex[Random.Range(0, _purityScenesIndex.Count)];
                break;
            case 2:
                Debug.Log("Need Hapiness");
                sceneIndex = _hapinessScenesIndex[Random.Range(0, _hapinessScenesIndex.Count)];
                break;
        }

        return sceneIndex;
    }

    public void OnButtonClick ()
    {
        if (PlayerPrefs.HasKey("Energy") && PlayerPrefs.GetFloat("Energy") > _energyValueWhenWatchVideoForEnergyActivated)
            SceneManager.LoadScene(ChooseLevel());
        else
            ActivateWatchVideoForEnergy();
    }

    private void ActivateWatchVideoForEnergy ()
    {
        _watchVideoForEnergy.DOFade(1, 0.25f);
        _watchVideoForEnergy.alpha = 1;
        _watchVideoForEnergy.interactable = true;
        GetComponent<Button>().interactable = false;
    }

    private int GetRandomSceneIndex ()
    {
        return Random.Range(1, SceneManager.sceneCountInBuildSettings);
    }
}
