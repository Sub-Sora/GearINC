public class EventElec : EventMap
{
    public bool EventHappend;
    public override void EventBegin()
    {
        //Eteindre les lumi�res
    }

    public void FinishTheEvent()
    {
        if( EventHappend)
        {
            EventHappend = false;
        }
    }
}