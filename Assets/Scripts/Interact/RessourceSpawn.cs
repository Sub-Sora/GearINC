using UnityEngine;

public class RessourceSpawn : Interactable
{
    [SerializeField]
    private GameObject _ressourceToSpawn;

    [SerializeField]
    private Transform _posSpawn;

    public override void Interact(PlayerMain player)
    {
        //Fait spawn les mat�riaux
        Instantiate(_ressourceToSpawn, _posSpawn);
    }
}