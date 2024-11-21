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

    private void Init(ManagerOnce main)
    {
        Main = main;
        Elec = new EventElec();
        Engine = new EventBrokenEngine();

        Engine.SetEvents(this);
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
}