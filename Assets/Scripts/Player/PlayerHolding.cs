using UnityEngine;

public class PlayerHolding : MonoBehaviour
{
    public GameObject ObjectHolding;
    public bool IsHolding;

    private void Init(PlayerMain main)
    {
        main.Holding = this;
    }

    /// <summary>
    /// Permet de prendre un objet
    /// </summary>
    /// <param name="objectToHold"></param>
    public void TakeObject(GameObject objectToHold)
    {
        ObjectHolding = objectToHold;
        IsHolding = true;
    }

    /// <summary>
    /// Permet de d�poser un objet
    /// </summary>
    public void LoseObject()
    {
        ObjectHolding = null;
        IsHolding = false;
    }
}