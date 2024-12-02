using UnityEngine;
using UnityEngine.VFX;
using static Job;
using static Objects;

public class AreaEngine : Interactable, IRessourceHolder
{
    [Header("Base Game")]
    public bool isHolding;
    public GameObject Engine;
    public JobType EngineType;
    public Ressource Ressource;
    private AreasEnginesManager _manager;
    private int _engineId;
    public int EngineId { get { return _engineId; } }

    [Header("Gameplay en plus")]
    [SerializeField]
    private ObjectType _typeNeededToRepairEngine;
    public VisualEffect SmokeEffect;
    private bool EngineInFire;

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
        if (!_manager.Main.NewGameplayIsAdd || !EngineInFire)
        {
            if (player.Job.EnginePut != null)
            {
                if (Engine != null)
                {
                    Destroy(Engine);
                }

                EngineType = player.Job.Job;
                Engine = Instantiate(player.Job.EnginePut, transform);
            }
        }
        else if (player.Holding.HoldingObjectType == _typeNeededToRepairEngine)
        {
            RepairTheEngine();
        }
    }

    /// <summary>
    /// Permet de vérifier si le job est le bon
    /// </summary>
    public bool VerifyEngine()
    {
        if (_manager.Main.Objective.Object.TypesNeeded[_engineId] == EngineType)
        {
            if (_manager.Main.Objective.Object.TypesNeeded.Count - 1 == _engineId)
            {
                _manager.Main.UI.Victory();
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public void Complete()
    {
        bool theConceptionIsCorrect = VerifyEngine();
        if (theConceptionIsCorrect)
        {
            Ressource.RessourceState++;
            
        }
        else
        {
            Ressource.RessourceState = -1;
        }

        _manager.Main.Event.ConceptionIsConplete(theConceptionIsCorrect, this);
    }

    public void GetRessource(Ressource ressource)
    {
        Ressource = ressource;
        isHolding = true;
        Ressource.RessourceAsset.transform.parent = transform;
    }

    public void LoseRessource()
    {
        Ressource = null;
        isHolding = false;
    }

    public void BrokeTheEngine()
    {
        EngineInFire = true;
        SmokeEffect.Play();
    }

    public void RepairTheEngine()
    {
        EngineInFire = false;
        SmokeEffect.Stop();
        _manager.Main.Event.Engine.FinishTheEvent();
    }
}