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
                //RessourceAsset.GetComponent<MeshRenderer>().material = BrokeRessourceColor;
            }
        }
    }

    public GameObject RessourceAsset;
    public Material BrokeRessourceColor;
}