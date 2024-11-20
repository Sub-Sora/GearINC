using UnityEngine;

public class ElecInteract : Interactable
{
    [SerializeField]
    private EventElec _eventElec;

    public override void Interact(PlayerMain player)
    {
        if (_eventElec.EventHappend)
        {
            _eventElec.FinishTheEvent();
        }
    }
}