using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public bool EngineIsBroken;
    public bool ElecIsBroken;
    public event Action ConceptionIsBlocked;

    [HideInInspector]
    public EventElec Elec;

    [HideInInspector]
    public EventBrokenEngine Engine;

    public EventTrash Trash;

    [HideInInspector]
    public ManagerOnce Main;

    [SerializeField]
    private GameObject _light;

    [Header("Chance to begin specific event")]

    [SerializeField]
    private float _percentTrashEvent;

    [SerializeField]
    private float _percentBadConceptionEngineBroken;

    [SerializeField]
    private float _percentBadConceptionElec;

    [SerializeField]
    private float _percentGoodConceptionEngineBroken;

    [SerializeField]
    private float _percentGoodConceptionElec;

    private void Init(ManagerOnce main)
    {
        Main = main;
        main.Event = this;
        Elec = new EventElec();
        Elec.Light = _light;
        Engine = new EventBrokenEngine();
        Engine.SetEvents(this);

        if (UnityEngine.Random.Range(0f, 101f) <= _percentTrashEvent && Main.NewGameplayIsAdd)
        {
            BeginTrashEvent();
        }
    }

    public void BeginElecEvent()
    {
        Elec.EventBegin();
    }
    public void BeginEngineEvent()
    {
        Engine.EventBegin();
    }
    public void BeginTrashEvent()
    {
        Trash.EventBegin();
    }

    public void ConceptionIsConplete(bool completeIsCorrect, AreaEngine brokenEngine)
    {
        if (Main.NewGameplayIsAdd)
        {
            Engine.EngineBroken = brokenEngine;
            if (completeIsCorrect)
            {
                if (UnityEngine.Random.Range(0f, 101f) <= _percentGoodConceptionEngineBroken)
                {
                    BeginEngineEvent();
                }

                if (UnityEngine.Random.Range(0f, 101f) <= _percentGoodConceptionElec)
                {
                    BeginElecEvent();
                }
            }
            else
            {
                if (UnityEngine.Random.Range(0f, 101f) <= _percentBadConceptionEngineBroken)
                {
                    BeginEngineEvent();
                }

                if (UnityEngine.Random.Range(0f, 101f) <= _percentBadConceptionElec)
                {
                    BeginElecEvent();
                }
            }
        }
    }

    public void StopMachine()
    {
        ConceptionIsBlocked.Invoke();
    }
}