using UnityEngine;

public class PlayerRessource : MonoBehaviour, IRessourceHolder
{
    public Ressource RessourceHold;
    public bool IsHolding;
    private PlayerMain _main;

    private void Init(PlayerMain main)
    {
        main.Ressource = this;
        _main = main;
    }

    /// <summary>
    /// Permet de créer une nouvelle ressource
    /// </summary>
    /// <param name="newRessource"></param>
    public void GetNewRessource(GameObject newRessource, Material brokeRessourceColor)
    {
        RessourceHold = new Ressource();
        RessourceHold.RessourceState = 0;
        RessourceHold.BrokeRessourceColor = brokeRessourceColor;
        RessourceHold.RessourceAsset = newRessource;
        HoldRessource();
    }

    public void GetRessource(Ressource ressource)
    {
        RessourceHold = ressource;
        HoldRessource();
    }

    private void HoldRessource()
    {
        _main.Holding.TakeObject(RessourceHold.RessourceAsset);
        IsHolding = true;
        RessourceHold.RessourceAsset.transform.parent = transform;
    }

    public void LoseRessource()
    {
        RessourceHold = null;
        IsHolding = false;
    }
}