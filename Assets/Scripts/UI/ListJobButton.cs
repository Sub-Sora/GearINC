using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListJobButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _levelJob;

    [SerializeField]
    private GameObject _allJob;

    public void LevelJobList()
    {
        _levelJob.SetActive(true);
        _allJob.SetActive(false);
    }

    public void AllJobList()
    {
        _levelJob.SetActive(false);
        _allJob.SetActive(true);
    }
}
