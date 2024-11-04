using UnityEngine;
using static Job;

public class AreaEngine : Interactable
{
    public GameObject Engine;
    public JobType EngineType;
    private AreasEnginesManager _manager;
    private int _engineId;

    /// <summary>
    /// Initie l'areasEnginesManager et set la position de l'AreaEngine
    /// </summary>
    /// <param name="manager"></param>
    private void Init(AreasEnginesManager manager)
    {
        _manager = manager;
        for (int i = 0; i < manager.EngineList.Count; i++)
        {
            if (manager.EngineList[i] == this)
            {
                _engineId = i;
            }
        }
    }

    /// <summary>
    /// Ce lancera lorsque le joueur interragira avec
    /// </summary>
    public override void Interact()
    {
        VerifyEngine();
    }

    /// <summary>
    /// Permet de vérifier si le job est le bon
    /// </summary>
    private void VerifyEngine()
    {
        if (_manager.Objective.Object.TypesNeeded[_engineId] == EngineType)
        {
            Debug.Log("Verify!");
        }
    }
}