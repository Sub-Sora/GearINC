using UnityEngine;

public class ExtinguisherInteract : ObjectInteract
{
    [SerializeField]
    private Transform _objectPos;

    private Vector3 _objectScale;
    private void Start()
    {
        _objectScale = _object.transform.localScale;
        Type = Objects.ObjectType.extinguisher;
    }

    public override void Interact(PlayerMain player)
    {
        base.Interact(player);
        if (player.Holding.IsHolding)
        {
            if (player.Holding.HoldingObjectType == Type)
            {
                player.Holding.LoseObject();
                _object.transform.parent = _objectPos;
                _object.transform.localPosition = Vector3.zero;
                _object.transform.localRotation = Quaternion.identity;
                _object.transform.localScale = _objectScale;
            }
        }
    }
}