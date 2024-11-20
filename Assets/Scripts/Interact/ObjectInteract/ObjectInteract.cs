using UnityEngine;
using static Objects;

public class ObjectInteract : Interactable
{
    public ObjectType Type;

    [SerializeField]
    private Transform _objectPos;

    [SerializeField]
    private GameObject _object;

    private Transform _objectPosPrefab;

    private Vector3 _objectScale;

    internal virtual void Start()
    {
        _objectScale = _object.transform.localScale;
    }

    public override void Interact(PlayerMain player)
    {
        
        if (!player.Holding.IsHolding)
        {
            player.Holding.TakeObject(_object, Type);
            player.Holding.HoldObject(_object);
        }
        else if (player.Holding.HoldingObjectType == Type)
        {
            player.Holding.LoseObject();
            _object.transform.parent = _objectPos;
            _object.transform.localPosition = Vector3.zero;
            _object.transform.localRotation = Quaternion.identity;
            _object.transform.localScale = _objectScale;
        }
    }
}