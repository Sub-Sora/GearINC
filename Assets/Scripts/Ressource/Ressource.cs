using UnityEngine;

public class Ressource : MonoBehaviour
{
    private int _ressourceState;
    public int RessourceState
    {
        get { return _ressourceState; }
        set
        {
            _ressourceState = value;
            if (_ressourceState == -1)
            {
                BrokeRessourceColor.SetActive(true);
                RessourceColor.SetActive(false);
            }
        }
    }

    public GameObject RessourceAsset;
    public GameObject BrokeRessourceColor;
    public GameObject RessourceColor;
}