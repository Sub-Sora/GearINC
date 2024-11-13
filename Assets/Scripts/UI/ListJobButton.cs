using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListJobButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _levelJob;

    [SerializeField]
    private GameObject _allJob;

    [SerializeField]
    private GameObject _jobDescriptionTab;

    [SerializeField]
    private List<GameObject> _jobsDescription = new List<GameObject>();

    public void LevelJobList()
    {
        _levelJob.SetActive(true);
        _allJob.SetActive(false);
        _jobDescriptionTab.SetActive(false);
        foreach (var job in _jobsDescription)
        {
            job.SetActive(false);
        }
    }

    public void AllJobList()
    {
        _levelJob.SetActive(false);
        _allJob.SetActive(true);
        _jobDescriptionTab.SetActive(false);
        foreach (var job in _jobsDescription)
        {
            job.SetActive(false);
        }
    }

    public void CloseWindow()
    {
        _levelJob.SetActive(false);
        _allJob.SetActive(false);
        _jobDescriptionTab.SetActive(false);
        foreach (var job in _jobsDescription)
        {
            job.SetActive(false);
        }
    }
}
