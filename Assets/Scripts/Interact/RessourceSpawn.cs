using UnityEngine;

public class RessourceSpawn : Interactable
{
    [SerializeField]
    private Ressource _ressourceToSpawn;

    [SerializeField]
    private Transform _posSpawn;

    public override void Interact(PlayerMain player)
    {
        //Fait spawn les mat�riaux
        //Instantiate(_ressourceToSpawn, _posSpawn);
        player.Ressource.RessourceHold = new Ressource();
        player.Ressource.RessourceHold.RessourceState = 0;
    }
}