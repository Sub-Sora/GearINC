using Unity.VisualScripting;
using UnityEngine;
using static Objects;

public class PlayerHolding : MonoBehaviour
{
    public GameObject ObjectHolding;
    public bool IsHolding;
    public ObjectType HoldingObjectType;
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
        HoldingObjectType = ObjectType.none;
    }

    /// <summary>
    /// Permet de prendre un objet avec un type spécifique d'objet
    /// </summary>
    /// <param name="objectToHold"></param>
    /// <param name="holdingObjectType">Le type de l'objet</param>
    public void TakeObject(GameObject objectToHold, ObjectType holdingObjectType)
    {
        ObjectHolding = objectToHold;
        IsHolding = true;
        HoldingObjectType = holdingObjectType;
    }

    public void HoldObject(GameObject objectToHold)
    {
        objectToHold.transform.parent = transform;
    }

    /// <summary>
    /// Permet de déposer un objet
    /// </summary>
    public void LoseObject()
    {
        ObjectHolding = null;
        IsHolding = false;
        HoldingObjectType = ObjectType.none;
    }
}