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
        //Fait spawn les mat�riaux
        if (player.IsTuto)
        {
            if (gameObject == TutoManager.Instance.TutoPhases[TutoManager.Instance.TutoActualPeriod])
            {
                TutoManager.Instance.IngrementPeriod();
            }
            else
            {
                return;
            }
        }
        if (!player.Holding.IsHolding)
        {
            GameObject newRessource = Instantiate(_ressourceToSpawn, Vector3.zero, Quaternion.identity);
            player.Ressource.GetNewRessource(newRessource, _brokeRessourceColor);
        }
    }
}