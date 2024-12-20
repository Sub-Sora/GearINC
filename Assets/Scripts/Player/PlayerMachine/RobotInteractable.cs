using UnityEngine;

public class RobotInteractable : Interactable
{
    [SerializeField]
    private MachineInteract _machine;

    public override void Interact(PlayerMain player)
    {
        _machine.GetRessource(player.Ressource.RessourceHold);
        player.Ressource.LoseRessource();
    }
}