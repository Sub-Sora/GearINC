using UnityEngine;
using static Objects;

public class ObjectInteract : Interactable
{
    public ObjectType Type;

    [SerializeField]
    internal GameObject _object;

    public override void Interact(PlayerMain player)
    {
        if (!player.Holding.IsHolding)
        {
            Debug.Log(player.Holding.IsHolding);
            player.Holding.TakeObject(_object, Type);
            player.Holding.HoldObject(_object);
        }
    }
}