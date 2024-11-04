using UnityEngine;
using static Job;

public class Workstation : Interactable
{
    [SerializeField]
    private JobType _type;

    [SerializeField]
    private GameObject _engineToPut;

    [SerializeField]
    private Material _skinJob;


    public override void Interact(PlayerMain player)
    {
        player.Job.Job = _type;
        player.Job.EnginePut = _engineToPut;
        player.GetComponent<Renderer>().material = _skinJob;
    }
}