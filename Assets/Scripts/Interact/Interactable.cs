using UnityEngine;

public class Interactable : MonoBehaviour
{
    /// <summary>
    /// Ce lancera lorsque le joueur interragira avec
    /// </summary>
    public virtual void Interact(PlayerMain player)
    {
        Debug.Log("interact");
    }
}
