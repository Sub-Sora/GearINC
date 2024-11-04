using UnityEngine;
using static Job;

public class AreaEngine : Interactable
{
    public GameObject Engine;
    public JobType EngineType;
    private AreasEnginesManager _manager;

    /// <summary>
    /// Initie l'areasEnginesManager
    /// </summary>
    /// <param name="manager"></param>
    private void Init(AreasEnginesManager manager)
    {
        _manager = manager;
    }

    /// <summary>
    /// Ce lancera lorsque le joueur interragira avec
    /// </summary>
    public override void Interact()
    {

    }
}