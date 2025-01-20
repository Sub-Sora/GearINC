using UnityEngine;

public class RessourceSpawn : Interactable
{
    [SerializeField]
    private GameObject _ressourceToSpawn;

    [SerializeField]
    private Transform _posSpawn;

    [SerializeField]
    private GameObject _brokeRessourceColor;

    public override void Interact(PlayerMain player)
    {
        //Fait spawn les matériaux
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
            player.Ressource.GetNewRessource(newRessource, newRessource.transform.GetChild(1).gameObject, newRessource.transform.GetChild(0).gameObject);
        }
    }
}