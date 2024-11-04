using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public PlayerControls Controls;
    public PlayerInteract Interact;
    public PlayerJob Job;

    private void Awake()
    {
        SendMessage("Init", this);
    }
}
