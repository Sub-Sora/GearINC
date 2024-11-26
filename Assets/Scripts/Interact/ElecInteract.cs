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
        if (_event.ElecIsBroken)
        {
            _event.Elec.FinishTheEvent();
        }
    }
}