using UnityEngine;

public class EventElec : EventMap
{
    public GameObject Light;
    private EventManager _main;

    public void SetMachine(EventManager main)
    {
        _main = main;
    }

    public override void EventBegin()
    {
        _main.ElecIsBroken = true;
        Light.SetActive(false);
        _main.StopMachine();
    }

    public void FinishTheEvent()
    {
        if (_main.ElecIsBroken)
        {
            Light.SetActive(true);
            _main.ElecIsBroken = false;
        }
    }
}