using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTuto : MonoBehaviour
{
    [SerializeField]
    private GameObject _jobsTableWall;

    [SerializeField]
    private GameObject _engineRoomWall;

    [SerializeField]
    private GameObject _ressourcesRoomWall;

    private void Start()
    {
        TutoManager.Instance.firstRoomComplete += DisableJobsTableRoomWall;
        TutoManager.Instance.secondRoomComplete += DisableRessourcesRoomWall;
    }

    private void DisableJobsTableRoomWall()
    {
        _jobsTableWall.SetActive(false);
    }

    private void DisableRessourcesRoomWall()
    {
        _ressourcesRoomWall.SetActive(false);
    }

    private void DisableEngineRoomWall()
    {
        _engineRoomWall.SetActive(false);
    }

    
}
