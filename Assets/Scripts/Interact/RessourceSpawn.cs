using UnityEngine;

public class RessourceSpawn : Interactable
{
    [SerializeField]
    private GameObject _ressourceToSpawn;

    [SerializeField]
    private Transform _posSpawn;

    [SerializeField]
    private Material _brokeRessourceColor;

    public override void Interact(PlayerMain player)
    {
        //Fait spawn les matériaux
        if (!player.Holding.IsHolding)
        {
            GameObject newRessource = Instantiate(_ressourceToSpawn, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Quaternion.identity);
            player.Ressource.GetNewRessource(newRessource, _brokeRessourceColor);
        }
    }
}