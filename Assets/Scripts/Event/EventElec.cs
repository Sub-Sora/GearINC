public class EventElec : EventMap
{
    public bool EventHappend;
    public override void EventBegin()
    {
        //Eteindre les lumières
    }

    public void FinishTheEvent()
    {
        if( EventHappend)
        {
            EventHappend = false;
        }
    }
}