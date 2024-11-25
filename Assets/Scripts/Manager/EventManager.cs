using UnityEngine;

public class EventManager : MonoBehaviour
{
    [HideInInspector]
    public EventElec Elec;

    [HideInInspector]
    public EventBrokenEngine Engine;

    public EventTrash Trash;

    [HideInInspector]
    public ManagerOnce Main;

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
        Elec = new EventElec();
        Engine = new EventBrokenEngine();
        Engine.SetEvents(this);

        if (Random.Range(0f, 101f) <= _percentTrashEvent && Main.NewGameplayIsAdd)
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

    public void ConceptionIsConplete(bool completeIsCorrect)
    {
        if (Main.NewGameplayIsAdd)
        {
            if (completeIsCorrect)
            {
                if (Random.Range(0f, 101f) <= _percentGoodConceptionEngineBroken)
                {
                    BeginEngineEvent();
                }

                if (Random.Range(0f, 101f) <= _percentGoodConceptionElec)
                {
                    BeginElecEvent();
                }
            }
            else
            {
                if (Random.Range(0f, 101f) <= _percentBadConceptionEngineBroken)
                {
                    BeginEngineEvent();
                }

                if (Random.Range(0f, 101f) <= _percentBadConceptionElec)
                {
                    BeginEngineEvent();
                }
            }
        }
        
    }
}