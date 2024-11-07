using UnityEngine;
using static Job;

public class AreaEngine : Interactable
{
    public GameObject Engine;
    public JobType EngineType;
    public Ressource Ressource;
    private AreasEnginesManager _manager;
    private int _engineId;

    /// <summary>
    /// Initie l'areasEnginesManager et set la position de l'AreaEngine
    /// </summary>
    /// <param name="manager"></param>
    public void InitAreaEngine(AreasEnginesManager manager)
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
    public override void Interact(PlayerMain player)
    {
        if ( Engine != null )
        {
            VerifyEngine();
        }
        else if (player.Job.EnginePut != null)
        {
            EngineType = player.Job.Job;
            Engine = Instantiate(player.Job.EnginePut, transform);
        }
    }

    /// <summary>
    /// Permet de vérifier si le job est le bon
    /// </summary>
    private void VerifyEngine()
    {
        if (_manager.Main.Objective.Object.TypesNeeded[_engineId] == EngineType)
        {
            Debug.Log("Great");
        }
        else
        {
            Debug.Log("Bad");
        }
    }
}