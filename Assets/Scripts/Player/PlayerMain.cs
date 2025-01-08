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
    public bool IsTuto;

    // EVENTS //
    public delegate void PlayerAnim(bool isDoing);
    public PlayerAnim ControlPost;

    private void Awake()
    {
        SendMessage("Init", this);
    }
}
