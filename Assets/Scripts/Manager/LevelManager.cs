using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager: MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _workstation = new List<GameObject> ();

    [SerializeField]
    private List<Transform> _workstationSpot = new List<Transform>();

    [SerializeField]
    private List<GameObject> _engineSpot = new List<GameObject> ();

    private ManagerOnce _main;

    private void Init(ManagerOnce main)
    {
        _main = main;
        main.Level = this;
    }

    private void Start()
    {
        SetJobOnWorkstation();
        SetEngineSpot();
    }

    /// <summary>
    /// Va set tout les workstations, on toutes les poser ici
    /// </summary>
    private void SetJobOnWorkstation()
    {
        for (int i = 0;  i < _main.Objective.Object.AllJob.Count; i++)
        {
            for (int j = 0; j < _workstation.Count; j++)
            {
                if (_workstation[j].GetComponent<Workstation>().Type == _main.Objective.Object.AllJob[i])
                {
                    Workstation newWorkstation = Instantiate(_workstation[j], _workstationSpot[i]).GetComponent<Workstation>();
                    foreach (UIJobName jobName in _main.UI.JobName)
                    {
                        if (jobName.JobType == newWorkstation.Type)
                        {
                            jobName.transform.position = new Vector3 (_workstationSpot[i].position.x, _workstationSpot[i].position.y + 2, _workstationSpot[i].position.z);
                            newWorkstation.SetWorkstationJobName(jobName.gameObject);
                        }
                    }

                    foreach (JobSheet jobSheet in _main.UI.JobSheets)
                    {
                        if (jobSheet.JobType == newWorkstation.Type)
                        {

                            newWorkstation.SetWorkstationJobSheets(jobSheet);
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Va set tout les endroits pour poser les machines, va désactivé ceux qui ne seront pas présent pour le niveau
    /// </summary>
    private void SetEngineSpot()
    {
        int jobNeeded = _engineSpot.Count - _main.Objective.Object.TypesNeeded.Count;

        for (int i = 0; i < jobNeeded; i++)
        {
            _engineSpot[_engineSpot.Count-1].SetActive(false);
            _engineSpot.Remove(_engineSpot[_engineSpot.Count - 1]);
        }

        foreach(GameObject engine in _engineSpot)
        {
            _main.AreasEngines.EngineList.Add(engine.GetComponent<AreaEngine>());
        }

        _main.AreasEngines.InitAllAreaEngine();
        _main.Machine.InitializedPath(_main.AreasEngines.EngineList);
    }
}