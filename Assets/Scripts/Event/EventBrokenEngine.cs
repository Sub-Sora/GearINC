using UnityEngine;

public class EventBrokenEngine : EventMap
{
    private EventManager _main;
    public AreaEngine EngineBroken;

    public override void SetEvents(EventManager main)
    {
        _main = main;
    }

    public override void EventBegin()
    {
        EngineBroken.BrokeTheEngine();
        _main.StopMachine();
        _main.EngineIsBroken = true;
    }

    public void FinishTheEvent()
    {
        if (_main.EngineIsBroken)
        {
            _main.EngineIsBroken = false;
        }
    }
}