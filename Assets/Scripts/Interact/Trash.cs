public class Trash : Interactable
{
    public override void Interact(PlayerMain player)
    {
        if (player.Holding.IsHolding)
        {
            if (player.Ressource.IsHolding)
            {
                Destroy(player.Ressource.RessourceHold.RessourceAsset);
                player.Ressource.RessourceHold = null;
                player.Ressource.IsHolding = false;
            }

            if (player.Holding.HoldingObjectType == Objects.ObjectType.none)
            {
                Destroy(player.Holding.ObjectHolding);
                player.Holding.LoseObject();
            }
        }
    }
}