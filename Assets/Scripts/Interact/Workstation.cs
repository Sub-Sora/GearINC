using UnityEngine;
using static Job;

public class Workstation : Interactable
{
    public JobType Type;

    [SerializeField]
    private GameObject _engineToPut;

    [SerializeField]
    private Material _skinJob;


    public override void Interact(PlayerMain player)
    {
        player.Job.Job = Type;
        player.Job.EnginePut = _engineToPut;
        player.GetComponent<Renderer>().material = _skinJob;
    }
}