using UnityEngine;
using static Job;

public class Workstation : Interactable
{
    public JobType Type;

    [SerializeField]
    private GameObject _engineToPut;

    [SerializeField]
    private Material _skinJob;

    [SerializeField]
    private GameObject _UIPos;

    private GameObject _jobSheet;

    public override void Interact(PlayerMain player)
    {
        player.Job.Job = Type;
        player.Job.EnginePut = _engineToPut;
        player.GetComponent<Renderer>().material = _skinJob;
    }

    public void SetWorkstationJobName(GameObject uiJob)
    {
        _UIPos = uiJob;
    }

    public void SetWorkstationJobSheets(GameObject uiJob)
    {
        _jobSheet = uiJob;
    }

    /// <summary>
    /// Sera appelé lorsque le joueur s'approche de la workstation
    /// </summary>
    private void ShowJobView()
    {
        _UIPos.SetActive(true);
        _jobSheet.SetActive(true);
    }

    private void HideJobView()
    {
        _UIPos.SetActive(false);
    }
}