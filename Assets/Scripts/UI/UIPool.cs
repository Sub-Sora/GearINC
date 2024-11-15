using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPool : MonoBehaviour
{
    public List<UIJobName> JobName = new List<UIJobName>();

    public List<GameObject> JobDescriptionList = new List<GameObject>();

    public Image ObjectiveIcone;

    [SerializeField]
    private GameObject _victory;

    private ManagerOnce _main;

    private void Init(ManagerOnce main)
    {
        _main = main;
        main.UI = this;
    }

    private void Start()
    {
        SetObjectiveIcone();
    }

    /// <summary>
    /// Se lance lorqu'on gagne une partie
    /// </summary>
    public void Victory()
    {
        _victory.SetActive(true);
    }

    /// <summary>
    /// Va set l'icone de l'objectif
    /// </summary>
    private void SetObjectiveIcone()
    {
        ObjectiveIcone.sprite = _main.Objective.Object.ObjectiveIcone;
    }
}
