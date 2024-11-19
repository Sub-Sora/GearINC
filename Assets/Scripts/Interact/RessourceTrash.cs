public class RessourceTrash : Interactable
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
        }
    }
}