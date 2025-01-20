using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.VFX;
using static Job;
using static Objects;

public class AreaEngine : Interactable, IRessourceHolder
{
    [Header("Base Game")]
    public bool isHolding;
    public GameObject Engine;
    public AnimInteract EngineAnimator;
    public JobType EngineType;
    public Ressource Ressource;

    [SerializeField]
    private Transform _enginePos;
    [SerializeField]
    private GameObject _ressourceIcone;
    [SerializeField]
    private GameObject _ressourceBrokenIcone;

    private AreasEnginesManager _manager;
    private int _engineId;
    public int EngineId { get { return _engineId; } }

    [SerializeField]
    private GameObject _pc;

    [SerializeField]
    private AreaEngineEffect _effect;

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
        if (player.IsTuto)
        {
            if (gameObject == TutoManager.Instance.TutoPhases[TutoManager.Instance.TutoActualPeriod])
            {
                TutoManager.Instance.IngrementPeriod();
            }
            else
            {
                return;
            }
        }
        if (!_manager.Main.NewGameplayIsAdd || !EngineInFire)
        {
            if (isHolding)
            {
                if (Ressource.RessourceState == -1)
                {
                    player.Ressource.GetRessource(Ressource);
                    LoseRessource();
                    return;
                }
            }
            if (player.Job.EnginePut != null)
            {
                if (Engine != null)
                {
                    Destroy(Engine);
                }

                EngineType = player.Job.Job;
                foreach (AreaEngine engine in _manager.EngineList)
                {
                    if (engine.EngineType == EngineType && engine.gameObject != gameObject)
                    {
                        engine.EngineType = JobType.none;
                        Destroy(engine.Engine);
                    }
                }

                Engine = Instantiate(player.Job.EnginePut, _enginePos);
                EngineAnimator = Engine.GetComponent<AnimInteract>();
                EngineAnimator.Engine = this;
                if (VerifyEngine()) ScoreManager.Instance.BadPlacment.Invoke();
            }
        }
        else if (player.Holding.HoldingObjectType == _typeNeededToRepairEngine)
        {
            RepairTheEngine();
        }

    }

    private void PutEngine(PlayerMain player)
    {
        EngineType = player.Job.Job;
        Engine = Instantiate(player.Job.EnginePut, _enginePos);
    }

    /// <summary>
    /// Permet de vérifier si le job est le bon
    /// </summary>
    public bool VerifyEngine()
    {
        if (_manager.Main.Objective.Object.TypesNeeded[_engineId] == EngineType)
        {
            if (_manager.Main.Objective.Object.TypesNeeded.Count - 1 == _engineId && isHolding)
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
        if (_manager.Main.Tuto)
        {
            if (_pc == TutoManager.Instance.TutoPhases[TutoManager.Instance.TutoActualPeriod])
            {
                TutoManager.Instance.IngrementPeriod();
            }
            else
            {
                return;
            }
        }

        bool theConceptionIsCorrect = VerifyEngine();
        if (theConceptionIsCorrect)
        {
            Ressource.RessourceState++;
            _effect.AnimClear();
        }
        else
        {
            Ressource.RessourceState = -1;
            _ressourceIcone.gameObject.SetActive(false);
            _ressourceBrokenIcone.gameObject.SetActive(true);
            _manager.Main.Machine._interact.ChangeEngineTarget(0);
            _effect.AnimFailed();
        }

        if (_manager.Main.NewGameplayIsAdd)
        {
            _manager.Main.Event.ConceptionIsConplete(theConceptionIsCorrect, this);
        }
    }

    public void GetRessource(Ressource ressource)
    {
        Ressource = ressource;
        isHolding = true;
        Ressource.RessourceAsset.transform.SetParent(transform, false);
        Ressource.RessourceAsset.SetActive(false);
        _ressourceIcone.transform.parent.gameObject.SetActive(true);
        _ressourceIcone.gameObject.SetActive(true);
        _ressourceBrokenIcone.gameObject.SetActive(false);
        _effect.GetARessource();
    }

    public void LoseRessource()
    {
        Ressource.RessourceAsset.SetActive(true);
        Ressource = null;
        isHolding = false;
        _ressourceIcone.transform.parent.gameObject.SetActive(false);
        _effect.DesactivateCircle();
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