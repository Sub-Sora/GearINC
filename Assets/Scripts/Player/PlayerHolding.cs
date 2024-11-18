using UnityEngine;

public class PlayerHolding : MonoBehaviour
{
    public GameObject ObjectHolding;
    private bool _isHolding;

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
        if (!_isHolding)
        {
            ObjectHolding = objectToHold;
            _isHolding = true;
        }
    }
}