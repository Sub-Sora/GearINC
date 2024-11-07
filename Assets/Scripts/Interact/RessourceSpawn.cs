using UnityEngine;

public class RessourceSpawn : Interactable
{
    /*[SerializeField]
    private Ressource _ressourceToSpawn;*/

    [SerializeField]
    private Transform _posSpawn;

    [SerializeField]
    private ParticleSystem _particle;

    public override void Interact(PlayerMain player)
    {
        //Fait spawn les matériaux
        //Instantiate(_ressourceToSpawn, _posSpawn);
        player.Ressource.RessourceHold = new Ressource();
        player.Ressource.RessourceHold.RessourceState = 0;
        _particle.Play();
    }
}