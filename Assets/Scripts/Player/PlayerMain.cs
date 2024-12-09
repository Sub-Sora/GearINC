using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public PlayerControls Controls;
    public PlayerInteract Interact;
    public PlayerJob Job;
    public PlayerRessource Ressource;
    public PlayerTrigger Trigger;
    public PlayerVFX VFX;
    public PlayerHolding Holding;

    private void Awake()
    {
        SendMessage("Init", this);
    }
}
