using UnityEngine;

public class EventElec : EventMap
{
    public bool EventHappend;
    public GameObject Light;

    public override void EventBegin()
    {
        EventHappend = true;
        Light.SetActive(false);
    }

    public void FinishTheEvent()
    {
        UnityEngine.Debug.Log("allum�e");
        if ( EventHappend)
        {
            Light.SetActive(true);
            EventHappend = false;
        }
    }
}