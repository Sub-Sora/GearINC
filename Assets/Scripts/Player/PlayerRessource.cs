using UnityEngine;

public class PlayerRessource : MonoBehaviour, IRessourceHolder
{
    public Ressource RessourceHold;
    public bool IsHolding;

    private void Init(PlayerMain main)
    {
        main.Ressource = this;
    }

    /// <summary>
    /// Permet de créer une nouvelle ressource
    /// </summary>
    /// <param name="newRessource"></param>
    public void GetNewRessource(GameObject newRessource)
    {
        RessourceHold = new Ressource();
        RessourceHold.RessourceState = 0;
        RessourceHold.RessourceAsset = newRessource;
        RessourceHold.RessourceAsset.transform.parent = transform;
        IsHolding = true;
    }

    public void GetRessource(Ressource ressource)
    {
        RessourceHold = ressource;
        IsHolding = true;
        ressource.RessourceAsset.transform.parent = transform;
    }

    public void LoseRessource()
    {
        RessourceHold = null;
        IsHolding = false;
    }
}