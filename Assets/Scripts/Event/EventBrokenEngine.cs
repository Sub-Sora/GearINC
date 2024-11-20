using UnityEngine;

public class EventBrokenEngine : EventMap
{
    public bool EventHappend;
    private EventManager _main;

    public override void SetEvents(EventManager main)
    {
        _main = main;
    }

    public override void EventBegin()
    {
        _main.Main.AreasEngines.EngineList[Random.Range(0, _main.Main.AreasEngines.EngineList.Count)].BrokeTheEngine();
    }

    public void FinishTheEvent()
    {
        if (EventHappend)
        {
            EventHappend = false;
        }
    }
}