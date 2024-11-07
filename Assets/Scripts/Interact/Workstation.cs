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

    public override void Interact(PlayerMain player)
    {
        player.Job.Job = Type;
        player.Job.EnginePut = _engineToPut;
        player.GetComponent<Renderer>().material = _skinJob;
    }

    public void SetWorkstation(GameObject uiJob)
    {
        _UIPos = uiJob;
    }

    /// <summary>
    /// Sera appel� lorsque le joueur s'approche de la workstation
    /// </summary>
    private void ShowJobView()
    {
        _UIPos.SetActive(true);
    }

    private void HideJobView()
    {
        _UIPos.SetActive(false);
    }
}