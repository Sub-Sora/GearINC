using UnityEngine;

public class PlayerRessource : MonoBehaviour, IRessourceHolder
{
    public Ressource RessourceHold;
    public bool IsHolding;
    private PlayerMain _main;
    public Transform RessourceParent;

    private void Init(PlayerMain main)
    {
        main.Ressource = this;
        _main = main;
    }

    /// <summary>
    /// Permet de cr�er une nouvelle ressource
    /// </summary>
    /// <param name="newRessource"></param>
    public void GetNewRessource(GameObject newRessource, GameObject brokeRessourceColor, GameObject ressourceColor)
    {
        RessourceHold = new Ressource();
        RessourceHold.RessourceState = 0;
        RessourceHold.BrokeRessourceColor = brokeRessourceColor;
        RessourceHold.RessourceColor = ressourceColor;
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
        RessourceHold.RessourceAsset.transform.SetParent(RessourceParent, false);
    }

    public void LoseRessource()
    {
        _main.Holding.LoseObject();
        RessourceHold = null;
        IsHolding = false;
    }
}