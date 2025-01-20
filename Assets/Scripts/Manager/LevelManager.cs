using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _workstation = new List<GameObject>();

    [SerializeField]
    private List<Transform> _workstationSpot = new List<Transform>();

    [SerializeField]
    private List<GameObject> _engineSpot = new List<GameObject>();

    [SerializeField]
    private MeshFilter _hologramMesh;

    private ManagerOnce _main;

    private void Init(ManagerOnce main)
    {
        _main = main;
        main.Level = this;
    }

    private void Start()
    {
        if (_main.Tuto)
        {
            SetAllTutoWorkstation();
        }
        else
        {
            SetAllWorkstation();
        }

        SetEngineSpot();
        SetHologramMesh();
    }

    /// <summary>
    /// Va set tout les workstations, on toutes les poser ici
    /// </summary>
    private void SetAllWorkstation()
    {
        for (int i = 0; i < _main.Objective.Object.AllJob.Count; i++)
        {
            for (int j = 0; j < _workstation.Count; j++)
            {
                if (_workstation[j].GetComponent<Workstation>().Type == _main.Objective.Object.AllJob[i])
                {
                    Workstation newWorkstation = Instantiate(_workstation[j], _workstationSpot[i]).GetComponent<Workstation>();
                    SetJobOnWorkstation(newWorkstation, i);
                    /*newWorkstation.Main = _main;

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
                    }*/
                }
            }
        }
    }

    private void SetAllTutoWorkstation()
    {
        for (int i = 0; i < _main.Objective.Object.AllJob.Count; i++)
        {
            for (int j = 0; j < TutoManager.Instance.TutoWorkstations.Count; j++)
            {
                Workstation actualWorkstation = TutoManager.Instance.TutoWorkstations[j].GetComponent<Workstation>();
                if (actualWorkstation.Type == _main.Objective.Object.AllJob[i])
                {
                    SetJobOnWorkstation(actualWorkstation, j);
                }
            }
        }
    }

    private void SetJobOnWorkstation(Workstation workstation, int actualWorkstationSpot)
    {
        workstation.Main = _main;
        foreach (UIJobName jobName in _main.UI.JobName)
        {
            if (jobName.JobType == workstation.Type)
            {
                jobName.transform.position = new Vector3(_workstationSpot[actualWorkstationSpot].position.x, _workstationSpot[actualWorkstationSpot].position.y + 2, _workstationSpot[actualWorkstationSpot].position.z);
                workstation.SetWorkstationJobName(jobName.gameObject);
            }
        }

        foreach (JobSheet jobSheet in _main.UI.JobSheets)
        {
            if (jobSheet.JobType == workstation.Type)
            {
                workstation.SetWorkstationJobSheets(jobSheet);
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
            _engineSpot[_engineSpot.Count - 1].SetActive(false);
            _engineSpot.Remove(_engineSpot[_engineSpot.Count - 1]);
        }

        foreach (GameObject engine in _engineSpot)
        {
            _main.AreasEngines.EngineList.Add(engine.GetComponent<AreaEngine>());
        }

        _main.AreasEngines.InitAllAreaEngine();
        _main.Machine.InitializedPath(_main.AreasEngines.EngineList);
    }

    private void SetHologramMesh()
    {
        _hologramMesh.mesh = _main.Objective.Object.ObjectiveMesh;
    }
}