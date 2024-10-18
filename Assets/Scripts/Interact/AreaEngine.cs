using UnityEngine;
using static Job;

public class AreaEngine : Interactable
{
    public GameObject Engine;
    public JobType EngineType;
    private AreasEnginesManager _manager;

    private void Init(AreasEnginesManager manager)
    {
        _manager = manager;
    }

    public override void Interact()
    {

    }
}