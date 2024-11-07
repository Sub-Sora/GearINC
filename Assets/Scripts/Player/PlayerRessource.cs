using UnityEngine;

public class PlayerRessource : MonoBehaviour
{
    public Ressource RessourceHold;

    private void Init(PlayerMain main)
    {
        main.Ressource = this;
    }
}