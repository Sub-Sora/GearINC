using UnityEngine;

public class RessourceSpawn : Interactable
{
    [SerializeField]
    private GameObject _ressourceToSpawn;

    [SerializeField]
    private Transform _posSpawn;

    public override void Interact(PlayerMain player)
    {
        //Fait spawn les matériaux
        GameObject newRessource = Instantiate(_ressourceToSpawn, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Quaternion.identity);
        player.Ressource.RessourceHold = new Ressource();
        player.Ressource.RessourceHold.RessourceState = 0;
        player.Ressource.RessourceHold.RessourceAsset = newRessource;
        player.Ressource.RessourceHold.RessourceAsset.transform.parent = player.transform;
        player.Ressource.IsHolding = true;
    }
}