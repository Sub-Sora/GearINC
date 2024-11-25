using UnityEngine;

public class ElecInteract : Interactable
{
    [SerializeField]
    private EventManager _event;

    private void Start()
    {
        _event = FindAnyObjectByType<EventManager>();
    }

    public override void Interact(PlayerMain player)
    {
        if (_event.Elec.EventHappend)
        {
            _event.Elec.FinishTheEvent();
        }
    }
}