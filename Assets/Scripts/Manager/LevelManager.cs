using System.Collections.Generic;
using UnityEngine;

public class LevelManager: MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _workstation = new List<GameObject> ();

    [SerializeField]
    private List<Transform> _workstationSpot = new List<Transform>();

    [SerializeField]
    private List<GameObject> _engineSpot = new List<GameObject> ();

    private ManagerMain _main;

    private void Init(ManagerMain main)
    {
        _main = main;
        main.Level = this;
    }

    private void Start()
    {
        SetJobOnWorkstation();
        SetEngineSpot();
    }

    private void SetJobOnWorkstation()
    {
        for (int i = 0;  i < _main.Objective.Object.AllJob.Count; i++)
        {
            for (int j = 0; j < _workstation.Count; j++)
            {
                if (_workstation[j].GetComponent<Workstation>().Type == _main.Objective.Object.AllJob[i])
                {
                    Instantiate(_workstation[j], _workstationSpot[i]);
                }
            }
        }
    }

    private void SetEngineSpot()
    {
        int jobNeeded = _engineSpot.Count - _main.Objective.Object.TypesNeeded.Count;

        for (int i = 0; i < jobNeeded; i++)
        {
            _engineSpot[_engineSpot.Count-1].SetActive(false);
            _engineSpot.Remove(_engineSpot[_engineSpot.Count - 1]);
        }
    }
}