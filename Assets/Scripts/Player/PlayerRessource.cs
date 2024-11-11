using UnityEngine;

public class PlayerRessource : MonoBehaviour
{
    public Ressource RessourceHold;
    public bool IsHolding;

    private void Init(PlayerMain main)
    {
        main.Ressource = this;
    }
}